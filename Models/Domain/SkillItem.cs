namespace PortofolioASP.Models.Domain;

/// <summary>Satu teknologi di section "Tech Stack".</summary>
public class SkillItem
{
    /// <summary>Nama teknologi, mis. "JavaScript".</summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>Nama file/slug ikon SVG di wwwroot/icons, mis. "javascript".</summary>
    public string IconSlug { get; set; } = string.Empty;
}
