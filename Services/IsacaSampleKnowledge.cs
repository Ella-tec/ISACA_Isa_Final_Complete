namespace IsaChatApp.Services;

/// <summary>
/// Free, public-domain style ISACA overview samples for Foundation answers.
/// Not exam dumps — high-level public facts about credentials and frameworks
/// so TRU Ask can answer common chapter questions when content.db is empty.
/// </summary>
public static class IsacaSampleKnowledge
{
    public sealed record SamplePassage(string Document, string Section, string Page, string Text, string[] Keywords);

    public static IReadOnlyList<SamplePassage> All { get; } = new List<SamplePassage>
    {
        new(
            "ISACA Credential Overview",
            "CISA",
            "1",
            "CISA (Certified Information Systems Auditor) is an ISACA certification for professionals who audit, control, monitor, and assess information technology and business systems. CISA holders typically plan and conduct IS audits, evaluate controls, and report on compliance and risk. Domains commonly cover the audit process, IT governance, systems acquisition and development, operations and business resilience, and protection of information assets.",
            new[] { "cisa", "auditor", "audit", "information systems auditor", "certified information systems auditor" }),

        new(
            "ISACA Credential Overview",
            "CISM",
            "1",
            "CISM (Certified Information Security Manager) is an ISACA certification focused on managing, designing, and overseeing an enterprise information security program. It is aimed at managers rather than purely technical staff. Typical domains include information security governance, risk management, security program development and management, and incident management.",
            new[] { "cism", "security manager", "information security manager", "security program", "incident management" }),

        new(
            "ISACA Credential Overview",
            "CRISC",
            "1",
            "CRISC (Certified in Risk and Information Systems Control) is an ISACA certification for professionals who identify and manage IT risk and implement information systems controls. CRISC emphasizes risk identification, assessment, response, and monitoring, plus design and implementation of controls aligned to business objectives.",
            new[] { "crisc", "risk", "it risk", "information systems control", "controls" }),

        new(
            "ISACA Credential Overview",
            "CGEIT",
            "1",
            "CGEIT (Certified in the Governance of Enterprise IT) is an ISACA certification for professionals who govern enterprise IT, align IT with business strategy, and oversee value delivery, risk optimization, and resource management for IT.",
            new[] { "cgeit", "governance", "enterprise it", "it governance" }),

        new(
            "ISACA Credential Overview",
            "CDPSE",
            "1",
            "CDPSE (Certified Data Privacy Solutions Engineer) is an ISACA certification focused on privacy engineering and implementing privacy solutions across technology and business processes, including privacy governance, architecture, and lifecycle management.",
            new[] { "cdpse", "privacy", "data privacy", "privacy engineer" }),

        new(
            "ISACA Frameworks",
            "COBIT",
            "1",
            "COBIT is ISACA’s framework for the governance and management of enterprise information and technology. It helps organizations align IT with business goals, manage risk, and measure performance. COBIT is widely used for IT governance, assurance, and control activities and is often referenced together with risk and security programs.",
            new[] { "cobit", "framework", "it governance framework", "governance and management" }),

        new(
            "ISACA Frameworks",
            "COBIT for AI",
            "1",
            "Organizations can use COBIT principles to govern AI systems by defining objectives, assigning accountability, managing risk and compliance, and measuring outcomes. Effective AI governance includes ethical considerations, data quality, model lifecycle controls, and ongoing monitoring — areas where COBIT-style governance practices apply.",
            new[] { "cobit", "ai", "artificial intelligence", "ai governance", "ethical ai" }),

        new(
            "Chapter Support",
            "CPE and membership",
            "1",
            "ISACA certifications typically require continuing professional education (CPE) hours to maintain the credential. Chapter officers often help members find CPE opportunities through chapter events, webinars, and study groups. Always confirm current CPE rules on ISACA.org for the specific certification.",
            new[] { "cpe", "continuing professional education", "maintain", "renewal", "chapter event" }),

        new(
            "Chapter Support",
            "Study groups",
            "1",
            "Many ISACA chapters host exam study groups for CISA, CISM, CRISC, and other credentials. Study groups work best with a regular schedule, shared materials from official ISACA review resources, and practice questions that respect ISACA’s intellectual property rules (no unauthorized exam dumps).",
            new[] { "study group", "exam prep", "chapter", "review course" }),

        new(
            "Digital Trust",
            "Overview",
            "1",
            "Digital trust is the confidence stakeholders have that digital technologies, data, and processes are secure, reliable, and used ethically. ISACA promotes digital trust through frameworks, certifications, research, and chapter communities that support governance, risk, security, and audit professionals.",
            new[] { "digital trust", "trust", "isaca", "security", "governance risk" }),

        new(
            "Security Concepts",
            "Security debt",
            "1",
            "Security debt is the accumulation of unresolved security issues, deferred controls, and technical shortcuts that increase risk over time. Like technical debt, it can undermine resilience if not tracked and reduced through prioritized remediation, governance oversight, and continuous improvement.",
            new[] { "security debt", "technical debt", "remediation", "resilience", "controls gap" }),

        new(
            "Risk Management",
            "IT risk basics",
            "1",
            "IT risk management identifies, assesses, and responds to risks that could affect information and technology objectives. Common steps include establishing context, risk identification, analysis and evaluation, treatment (avoid, mitigate, transfer, accept), and ongoing monitoring and reporting to leadership.",
            new[] { "it risk", "risk management", "risk assessment", "risk treatment", "mitigate" }),
    };

    /// <summary>Score passages by keyword overlap with the question; return top matches.</summary>
    public static IReadOnlyList<SamplePassage> Search(string question, int limit = 5)
    {
        if (string.IsNullOrWhiteSpace(question))
            return Array.Empty<SamplePassage>();

        var q = question.ToLowerInvariant();
        var scored = All
            .Select(p =>
            {
                var score = 0;
                foreach (var kw in p.Keywords)
                {
                    if (q.Contains(kw, StringComparison.OrdinalIgnoreCase))
                        score += kw.Length > 4 ? 3 : 2;
                }
                // light text overlap
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

        return scored;
    }
}
