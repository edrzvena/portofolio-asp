using PortofolioASP.Models.Domain;

namespace PortofolioASP.Models.ViewModels;

/// <summary>
/// Root view model untuk halaman portfolio (Views/Home/Index.cshtml).
/// Diisi oleh IPortfolioService dari file JSON per bahasa.
/// Tiap section punya sub-view-model sendiri agar partial-nya rapi &amp; strongly-typed.
/// </summary>
public class PortfolioViewModel
{
    /// <summary>Label navigasi per id section (key = "skills", "experience", ...).</summary>
    public Dictionary<string, string> Nav { get; set; } = new();

    public HeroViewModel Hero { get; set; } = new();
    public SkillsSection Skills { get; set; } = new();
    public ExperienceSection Experience { get; set; } = new();
    public EducationSection Education { get; set; } = new();
    public CertificatesSection Certificates { get; set; } = new();
    public ProjectsSection Projects { get; set; } = new();
    public ContactSection Contact { get; set; } = new();
    public FooterSection Footer { get; set; } = new();
}

public class SkillsSection
{
    public string Heading { get; set; } = string.Empty;
    public string ToolsHeading { get; set; } = string.Empty;
    public List<SkillItem> Items { get; set; } = new();
    public List<string> Tools { get; set; } = new();
}

public class ExperienceSection
{
    public string Heading { get; set; } = string.Empty;
    public List<ExperienceItem> Items { get; set; } = new();
}

public class EducationSection
{
    public string Heading { get; set; } = string.Empty;
    public List<EducationItem> Items { get; set; } = new();
}

public class CertificatesSection
{
    public string Heading { get; set; } = string.Empty;
    public string VerifyLabel { get; set; } = string.Empty;
    public List<CertificateItem> Items { get; set; } = new();
}

public class ProjectsSection
{
    public string Heading { get; set; } = string.Empty;
    public string ViewAllLabel { get; set; } = string.Empty;
    public string ViewAllUrl { get; set; } = string.Empty;
    public string ViewProjectLabel { get; set; } = string.Empty;
    public List<ProjectItem> Items { get; set; } = new();
}

public class ContactSection
{
    public string Heading { get; set; } = string.Empty;
    public string FormHeading { get; set; } = string.Empty;
    public string NamePlaceholder { get; set; } = string.Empty;
    public string EmailPlaceholder { get; set; } = string.Empty;
    public string MessagePlaceholder { get; set; } = string.Empty;
    public string SendLabel { get; set; } = string.Empty;
    public List<SocialLink> Socials { get; set; } = new();
}

public class FooterSection
{
    public string Rights { get; set; } = string.Empty;
    public List<SocialLink> Links { get; set; } = new();
}
