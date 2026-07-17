namespace PortofolioASP.Models.Domain;

/// <summary>Tautan sosial (Email/LinkedIn/GitHub) yang dipakai di Contact &amp; Footer.</summary>
public class SocialLink
{
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;

    /// <summary>Slug ikon SVG di wwwroot/icons (mis. "mail", "linkedin", "github").</summary>
    public string IconSlug { get; set; } = string.Empty;
}
