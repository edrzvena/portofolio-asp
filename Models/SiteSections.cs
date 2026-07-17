namespace PortofolioASP.Models;

/// <summary>
/// Satu sumber kebenaran untuk daftar id section (dipakai navbar + scroll-spy).
/// Urutannya harus sama dengan urutan render di Views/Home/Index.cshtml.
/// </summary>
public static class SiteSections
{
    public static readonly IReadOnlyList<string> Ids = new[]
    {
        "skills",
        "experience",
        "education",
        "certificates",
        "projects",
        "contact",
    };
}
