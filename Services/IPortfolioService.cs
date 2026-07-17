using PortofolioASP.Models.ViewModels;

namespace PortofolioASP.Services;

/// <summary>Menyediakan seluruh konten portfolio untuk view.</summary>
public interface IPortfolioService
{
    /// <summary>
    /// Ambil konten portfolio untuk bahasa tertentu.
    /// Jika file bahasa tidak ada, otomatis fallback ke bahasa default (en).
    /// </summary>
    /// <param name="culture">Kode bahasa (mis. "en", "id", "ja").</param>
    PortfolioViewModel GetPortfolio(string culture = "en");
}
