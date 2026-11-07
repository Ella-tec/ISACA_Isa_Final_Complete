using Microsoft.Data.Sqlite;

namespace IsaChatApp.Services.Orchestrator.Stages;

/// <summary>Placeholder stages for stages owned by others (T11a / T11c).</summary>
public class PassThroughStage : IStage
{
    public string Name { get; }
    public PassThroughStage(string name) => Name = name;

    public Task<StageResult> RunAsync(QueryContext ctx)
        => Task.FromResult(new StageResult(StageOutcome.Pass, null, "placeholder"));
}

/// <summary>T11b — Database Search. FTS on content DB, then ISACA free-sample knowledge.</summary>
public class DatabaseSearchStage : IStage
{
    public string Name => "database_search";
    private readonly string _contentDbPath;
    private readonly IConfiguration _config;

    public DatabaseSearchStage(IConfiguration config)
    {
        _config = config;
        _contentDbPath = config["ContentDb:Path"] ?? Path.Combine("data", "content.db");
    }

    private static readonly HashSet<string> FtsStopWords = new(StringComparer.OrdinalIgnoreCase)
    {
        "the","how","many","what","does","must","each","year","have","our","and","who","are","for",
        "when","can","with","that","this","you","is","do","we","to","a","of","in","chapter","hold","policy","period","annual"
    };

    private static string? BuildFtsQuery(string question)
    {
        var terms = System.Text.RegularExpressions.Regex.Matches(question ?? "", "[A-Za-z0-9]+")
            .Select(m => m.Value)
            .Where(w => !FtsStopWords.Contains(w))
            .ToList();
        return terms.Count == 0 ? null : string.Join(" AND ", terms);
    }

    public async Task<StageResult> RunAsync(QueryContext ctx)
    {
        var passages = new List<Passage>();

        if (File.Exists(_contentDbPath))
        {
            await using var conn = new SqliteConnection($"Data Source={_contentDbPath};Mode=ReadOnly");
            await conn.OpenAsync();

            try
            {
                await using var cmd = conn.CreateCommand();
                cmd.CommandText = """
                    SELECT document, section, page, text
                    FROM passages
                    WHERE passages MATCH $q
                    ORDER BY rank
                    LIMIT 5;
                    """;
                var ftsQuery = BuildFtsQuery(ctx.Question);
                if (ftsQuery == null) throw new InvalidOperationException("no searchable terms");
                cmd.Parameters.AddWithValue("$q", ftsQuery);

                await using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    passages.Add(new Passage(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3)
                    ));
                }
            }
            catch
            {
                // Table may not exist yet
            }

            if (passages.Count > 0)
            {
                ctx.Passages = passages;
                ctx.DirectHit = true;
                ctx.Sources = passages.Select(p => new SourceRef(p.Document, p.Section, p.Page)).ToList();
                ctx.CitedSource = ctx.Sources[0];
                return new StageResult(StageOutcome.Pass, null, $"direct_hit; count={passages.Count}");
            }

            try
            {
                await using var cmd = conn.CreateCommand();
                cmd.CommandText = """
                    SELECT p.document, p.section, p.page, p.text
                    FROM meaning_map m
                    JOIN passages p ON p.id = m.passage_id
                    WHERE lower(m.question) = lower($q)
                    LIMIT 5;
                    """;
                cmd.Parameters.AddWithValue("$q", ctx.Question);

                await using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    passages.Add(new Passage(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3)
                    ));
                }
            }
            catch
            {
                // meaning_map may not exist yet
            }

            if (passages.Count > 0)
            {
                ctx.Passages = passages;
                ctx.DirectHit = false;
                ctx.Sources = passages.Select(p => new SourceRef(p.Document, p.Section, p.Page)).ToList();
                return new StageResult(StageOutcome.Pass, null, $"meaning_map; count={passages.Count}");
            }
        }

        // Fallback: built-in ISACA free-sample knowledge (CISA, CISM, CRISC, COBIT, etc.)
        var samples = IsacaSampleKnowledge.Search(ctx.Question, limit: 5);
        if (samples.Count > 0)
        {
            passages = samples
                .Select(s => new Passage(s.Document, s.Section, s.Page, s.Text))
                .ToList();
            ctx.Passages = passages;
            ctx.DirectHit = true;
            ctx.Sources = passages.Select(p => new SourceRef(p.Document, p.Section, p.Page)).ToList();
            ctx.CitedSource = ctx.Sources[0];
            if (string.IsNullOrEmpty(ctx.AnswerText))
                ctx.AnswerText = passages[0].Text;
            return new StageResult(StageOutcome.Pass, null, $"isaca_sample; count={passages.Count}");
        }

        return new StageResult(StageOutcome.Pass, null, "no_passages");
    }
}

/// <summary>T11b — Knowledge Graph stub. Returns empty related list for Foundation.</summary>
public class KnowledgeGraphStage : IStage
{
    public string Name => "knowledge_graph";

    public Task<StageResult> RunAsync(QueryContext ctx)
        => Task.FromResult(new StageResult(StageOutcome.Pass, null, "related=[]"));
}

/// <summary>T11b — RAG stub. Joins passages into context. Skips on direct hit.</summary>
public class RagStage : IStage
{
    public string Name => "rag";

    public Task<StageResult> RunAsync(QueryContext ctx)
    {
        if (ctx.DirectHit)
        {
            if (ctx.Passages.Count > 0 && string.IsNullOrEmpty(ctx.AnswerText))
                AnswerExtract.Apply(ctx);
            return Task.FromResult(new StageResult(StageOutcome.Pass, null, "direct hit", Skipped: true));
        }

        if (ctx.Passages.Count == 0)
        {
            return Task.FromResult(new StageResult(StageOutcome.Pass, null, "no_context"));
        }

        var contextText = string.Join("\n\n",
            ctx.Passages.Select(p => $"[{p.Document} / {p.Section} / p.{p.Page}]\n{p.Text}"));

        ctx.AnswerText = ctx.Passages[0].Text;
        ctx.Sources = ctx.Passages.Select(p => new SourceRef(p.Document, p.Section, p.Page)).ToList();

        return Task.FromResult(new StageResult(
            StageOutcome.Pass,
            null,
            $"context_chars={contextText.Length}; passages={ctx.Passages.Count}"
        ));
    }
}

/// <summary>Stub translation — pass-through. A'keyrah owns T11a.</summary>
public class TranslationStage : IStage
{
    public string Name => "translation";
    public Task<StageResult> RunAsync(QueryContext ctx)
        => Task.FromResult(ctx.Language == "en"
            ? new StageResult(StageOutcome.Pass, null, "english", Skipped: true)
            : new StageResult(StageOutcome.Pass, null, $"from={ctx.Language}"));
}

/// <summary>
/// Stub input_compliance — stops pizza / jailbreak; escalates harassment.
/// </summary>
public class InputComplianceStage : IStage
{
    public string Name => "input_compliance";

    public Task<StageResult> RunAsync(QueryContext ctx)
    {
        var q = ctx.Question.ToLowerInvariant();

        if (q.Contains("pizza") || q.Contains("ignore your rules") || q.Contains("show me every document"))
        {
            return Task.FromResult(new StageResult(
                StageOutcome.Stop,
                IsaChatApp.Services.ShowTheWork.Wording.OutsideScope,
                "out_of_scope"
            ));
        }

        if (q.Contains("harass") || q.Contains("harassment"))
        {
            ctx.SafetyTopic = true;
            return Task.FromResult(new StageResult(
                StageOutcome.Escalate,
                "Sensitive topic — escalating to a person",
                "sensitive"
            ));
        }

        return Task.FromResult(new StageResult(StageOutcome.Pass, null, "ok"));
    }
}
