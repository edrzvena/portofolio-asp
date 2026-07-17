namespace PortofolioASP.Models.Domain;

/// <summary>Satu kartu proyek.</summary>
public class ProjectItem
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    /// <summary>Path gambar relatif ke wwwroot, mis. "/img/daily_standup.jpg".</summary>
    public string ImagePath { get; set; } = string.Empty;

    /// <summary>URL repo/demo proyek.</summary>
    public string Link { get; set; } = string.Empty;
}
