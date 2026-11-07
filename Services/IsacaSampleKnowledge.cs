namespace IsaChatApp.Services;

/// <summary>
/// Hidden ISACA knowledge for TRU Ask intent recognition and answers.
/// NEVER surface these as UI buttons, cards, FAQs, or suggested prompts.
/// Used only when a user asks a related question (any wording).
/// </summary>
public static class IsacaSampleKnowledge
{
    public sealed record SamplePassage(string Document, string Section, string Page, string Text, string[] Keywords);

    public sealed record HiddenAnswer(
        string Id,
        string[] Keywords,
        string Answer,
        string? FollowUp = null);

    /// <summary>21 core Q&amp;As — background training only, not shown in the UI.</summary>
    public static IReadOnlyList<HiddenAnswer> TrainingAnswers { get; } = new List<HiddenAnswer>
    {
        new("isaca",
            new[] { "what is isaca", "about isaca", "isaca organization", "isaca association", "who is isaca" },
            "ISACA is a global professional association focused on digital trust, cybersecurity, IT audit, governance, risk management, privacy, and emerging technologies. ISACA provides certifications, frameworks, research, training, and professional communities that help technology professionals advance their careers.",
            "Would you like an overview of certifications, COBIT, membership, or local chapters?"),

        new("certifications",
            new[] { "what certifications", "isaca certifications", "isaca credentials", "which certification", "list of certifications" },
            "ISACA offers several globally recognized certifications including CISA, CISM, CRISC, CGEIT, CDPSE, and other credentials focused on digital trust, governance, cybersecurity, privacy, and risk management.",
            "Would you like details on CISA, CISM, CRISC, CGEIT, or CDPSE?"),

        new("cisa",
            new[] { "what is cisa", "cisa certification", "certified information systems auditor", "tell me about cisa", "cisa exam" },
            "CISA (Certified Information Systems Auditor) is a globally recognized certification for professionals who audit, monitor, and assess information systems and business processes.",
            "Would you like information about exam requirements, study resources, career paths, or certification costs?"),

        new("cism",
            new[] { "what is cism", "cism certification", "certified information security manager", "tell me about cism" },
            "CISM (Certified Information Security Manager) is designed for professionals who manage and oversee information security programs within organizations.",
            "Would you like guidance on eligibility, domains, or how CISM compares with CISA?"),

        new("crisc",
            new[] { "what is crisc", "crisc certification", "risk and information systems control", "tell me about crisc" },
            "CRISC (Certified in Risk and Information Systems Control) focuses on identifying, assessing, managing, and monitoring enterprise technology risks.",
            "Would you like more on risk domains, exam prep, or career paths with CRISC?"),

        new("cgeit",
            new[] { "what is cgeit", "cgeit certification", "governance of enterprise it", "tell me about cgeit" },
            "CGEIT (Certified in the Governance of Enterprise IT) validates expertise in governing enterprise technology and aligning IT strategy with business objectives.",
            "Would you like to explore governance practices or how CGEIT pairs with COBIT?"),

        new("cdpse",
            new[] { "what is cdpse", "cdpse certification", "data privacy solutions engineer", "tell me about cdpse", "privacy certification" },
            "CDPSE (Certified Data Privacy Solutions Engineer) focuses on privacy governance, data protection, and implementing privacy solutions.",
            "Would you like privacy framework guidance or related training resources?"),

        new("cobit",
            new[] { "what is cobit", "cobit framework", "about cobit", "tell me about cobit" },
            "COBIT is ISACA's governance and management framework that helps organizations create value from enterprise information and technology.",
            "Would you like how COBIT applies to AI governance, audit, or chapter use cases?"),

        new("digital-trust",
            new[] { "what is digital trust", "digital trust", "about digital trust" },
            "Digital trust is confidence in the security, privacy, reliability, and governance of digital systems and services.",
            "Would you like related certifications, frameworks, or chapter resources on digital trust?"),

        new("membership",
            new[] { "become a member", "isaca membership", "join isaca", "how do i become", "sign up for membership" },
            "You can become an ISACA member by creating an account on ISACA.org and selecting the membership option that best matches your professional goals.",
            "Would you like chapter benefits, student membership, or how membership supports CPE?"),

        new("chapters",
            new[] { "what are isaca chapters", "isaca chapter", "local chapter", "chapter community" },
            "ISACA chapters are local communities that provide networking, events, mentorship, volunteer opportunities, and professional development.",
            "Would you like help finding your local chapter or chapter event ideas?"),

        new("find-chapter",
            new[] { "find my local chapter", "find chapter", "chapter directory", "nearest chapter", "locate chapter" },
            "Use the Chapter Directory on ISACA.org to search for chapters by country, state, or city.",
            "Need help with chapter officer tools or upcoming chapter events?"),

        new("training",
            new[] { "what training", "isaca training", "training programs", "learning courses", "exam prep course" },
            "ISACA offers certification exam preparation courses, online learning, webinars, workshops, conferences, and professional development programs.",
            "Looking for CPE-friendly webinars, exam prep, or chapter study groups?"),

        new("journal",
            new[] { "isaca journal", "what is the isaca journal", "journal articles" },
            "The ISACA Journal provides research, insights, articles, and best practices related to cybersecurity, audit, governance, risk management, privacy, and emerging technologies.",
            "Would you like related white papers or current industry topics?"),

        new("white-paper",
            new[] { "white paper", "isaca white paper", "what is an isaca white paper" },
            "An ISACA white paper is a research-based publication that provides guidance, recommendations, and best practices on technology, governance, cybersecurity, risk, and privacy topics.",
            "Interested in security debt, AI governance, or COBIT-related papers?"),

        new("cpe",
            new[] { "earn cpe", "cpe credits", "continuing professional education", "how do i earn cpe", "maintain certification" },
            "CPE credits can be earned through ISACA training programs, webinars, chapter meetings, conferences, volunteer activities, and other approved learning opportunities.",
            "Would you like chapter event ideas that count toward CPE?"),

        new("exam-register",
            new[] { "register for exam", "schedule exam", "certification exam", "exam registration", "book the exam" },
            "Certification exams can be scheduled through your ISACA account on the ISACA website. Candidates can review eligibility requirements and exam scheduling options online.",
            "Need an overview of a specific credential's domains or study approach?"),

        new("careers",
            new[] { "career opportunities", "careers", "job roles", "career path", "supported by isaca" },
            "ISACA certifications support careers in cybersecurity, IT audit, privacy, governance, risk management, compliance, digital trust, and enterprise technology leadership.",
            "Which path interests you most — audit, security management, risk, or privacy?"),

        new("events",
            new[] { "what events", "isaca events", "conferences", "webinars", "chapter meetings" },
            "ISACA hosts conferences, webinars, workshops, certification preparation events, networking sessions, and chapter meetings worldwide.",
            "Want tips on finding events near you or CPE-eligible sessions?"),

        new("support",
            new[] { "contact isaca", "isaca support", "customer support", "help with membership", "technical support" },
            "ISACA support can help with membership, certification, training, exam scheduling, account management, chapter services, and technical support inquiries.",
            "You can also use TRU Contact for chapter support pathways."),

        new("tru-help",
            new[] { "how can tru help", "what can tru do", "help me", "what do you do", "about tru" },
            "TRU can help you find ISACA resources, explain certifications, locate chapter information, answer questions about governance, cybersecurity, privacy, risk management, digital trust, CPE requirements, training opportunities, and connect you with the appropriate support team when necessary.",
            "Ask anything about chapter operations, certifications, or approved guidance."),
    };

    public static IReadOnlyList<SamplePassage> All { get; } = BuildPassages();

    private static List<SamplePassage> BuildPassages()
    {
        var list = new List<SamplePassage>();
        foreach (var a in TrainingAnswers)
        {
            var text = a.FollowUp is null ? a.Answer : a.Answer + " " + a.FollowUp;
            list.Add(new SamplePassage(
                "ISACA Hidden Knowledge",
                a.Id,
                "1",
                text,
                a.Keywords));
        }

        // Extra retrieval passages for broader chapter context
        list.Add(new("Chapter Support", "Study groups", "1",
            "Many ISACA chapters host exam study groups for CISA, CISM, CRISC, and other credentials. Study groups work best with a regular schedule and shared materials from official ISACA review resources.",
            new[] { "study group", "exam prep", "chapter", "review course" }));
        list.Add(new("Security Concepts", "Security debt", "1",
            "Security debt is the accumulation of unresolved security issues, deferred controls, and technical shortcuts that increase risk over time and can undermine resilience if not tracked and reduced.",
            new[] { "security debt", "technical debt", "remediation", "resilience" }));
        list.Add(new("Risk Management", "IT risk basics", "1",
            "IT risk management identifies, assesses, and responds to risks affecting information and technology objectives: context, identification, analysis, treatment, and monitoring.",
            new[] { "it risk", "risk management", "risk assessment", "mitigate" }));

        return list;
    }

    /// <summary>
    /// Try to answer from hidden training content. Returns null if no confident match.
    /// Does not expose the training question list to the UI.
    /// </summary>
    public static string? TryAnswer(string question)
    {
        if (string.IsNullOrWhiteSpace(question))
            return null;

        var q = question.Trim().ToLowerInvariant();

        HiddenAnswer? best = null;
        var bestScore = 0;

        foreach (var item in TrainingAnswers)
        {
            var score = 0;
            foreach (var kw in item.Keywords)
            {
                if (q.Contains(kw, StringComparison.OrdinalIgnoreCase))
                    score += Math.Max(3, kw.Length / 2);
            }

            // Token overlap on id / key terms
            foreach (var token in q.Split(new[] { ' ', '?', '.', ',', '!', ';' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                if (token.Length < 3) continue;
                if (item.Id.Contains(token, StringComparison.OrdinalIgnoreCase))
                    score += 4;
                if (item.Answer.Contains(token, StringComparison.OrdinalIgnoreCase) && token.Length > 4)
                    score += 1;
            }

            if (score > bestScore)
            {
                bestScore = score;
                best = item;
            }
        }

        // Require a minimum score so random chatter does not force an answer
        if (best is null || bestScore < 4)
            return null;

        if (string.IsNullOrWhiteSpace(best.FollowUp))
            return best.Answer;

        return best.Answer + "\n\n" + best.FollowUp;
    }

    /// <summary>Score passages by keyword overlap; return top matches for RAG-style context.</summary>
    public static IReadOnlyList<SamplePassage> Search(string question, int limit = 5)
    {
        if (string.IsNullOrWhiteSpace(question))
            return Array.Empty<SamplePassage>();

        var q = question.ToLowerInvariant();
        return All
            .Select(p =>
            {
                var score = 0;
                foreach (var kw in p.Keywords)
                {
                    if (q.Contains(kw, StringComparison.OrdinalIgnoreCase))
                        score += kw.Length > 4 ? 3 : 2;
                }
                foreach (var word in q.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                {
                    if (word.Length < 4) continue;
                    if (p.Text.Contains(word, StringComparison.OrdinalIgnoreCase))
                        score += 1;
                }
                return (p, score);
            })
            .Where(x => x.score > 0)
            .OrderByDescending(x => x.score)
            .Take(limit)
            .Select(x => x.p)
            .ToList();
    }
}
