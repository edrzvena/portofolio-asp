namespace PortofolioASP.Models.Domain;

/// <summary>Satu entri di timeline Education.</summary>
public class EducationItem
{
    public string Title { get; set; } = string.Empty;
    public string Institution { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public List<string> Details { get; set; } = new();
}
