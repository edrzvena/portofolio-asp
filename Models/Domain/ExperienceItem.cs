namespace PortofolioASP.Models.Domain;

/// <summary>Satu entri di timeline Experience.</summary>
public class ExperienceItem
{
    public string Title { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public List<string> Tasks { get; set; } = new();
}
