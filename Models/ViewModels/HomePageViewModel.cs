using PortofolioASP.Models.Forms;

namespace PortofolioASP.Models.ViewModels;

/// <summary>Status pengiriman form kontak (untuk pesan feedback ke user).</summary>
public enum ContactStatus
{
    None,
    Success,
    Error,
}

/// <summary>
/// View model tingkat halaman untuk Views/Home/Index.cshtml.
/// Menggabungkan konten portfolio (dari service) dengan state form kontak
/// supaya validasi server-side &amp; repopulate input tetap jalan di halaman single-page.
/// </summary>
public class HomePageViewModel
{
    public PortfolioViewModel Portfolio { get; set; } = new();
    public ContactFormModel ContactForm { get; set; } = new();
    public ContactStatus Status { get; set; } = ContactStatus.None;
}

/// <summary>Model untuk partial _Contact: konten section + state form.</summary>
public class ContactViewModel
{
    public ContactSection Content { get; set; } = new();
    public ContactFormModel Form { get; set; } = new();
    public ContactStatus Status { get; set; } = ContactStatus.None;
}
