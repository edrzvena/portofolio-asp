namespace PortofolioASP.Models.ViewModels;

/// <summary>Satu angka statistik di Hero (nilai + label).</summary>
public class StatItem
{
    public string Value { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
}

/// <summary>Data untuk section Hero (#home).</summary>
public class HeroViewModel
{
    public string Quote { get; set; } = string.Empty;
    public string QuoteAuthor { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Greeting { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string GreetingSuffix { get; set; } = string.Empty;

    /// <summary>Baris tech stack di bawah judul, mis. "JavaScript / TypeScript / React".</summary>
    public string TechStack { get; set; } = string.Empty;

    public string ViewProjectsLabel { get; set; } = string.Empty;
    public string DownloadCvLabel { get; set; } = string.Empty;

    /// <summary>Path avatar relatif ke wwwroot.</summary>
    public string AvatarPath { get; set; } = string.Empty;

    /// <summary>Path file CV relatif ke wwwroot.</summary>
    public string CvPath { get; set; } = string.Empty;

    public List<StatItem> Stats { get; set; } = new();
}
