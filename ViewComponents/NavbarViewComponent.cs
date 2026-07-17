using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using PortofolioASP.Services;

namespace PortofolioASP.ViewComponents;

/// <summary>
/// Merender navbar dengan datanya sendiri (label nav dari IPortfolioService),
/// terpisah dari model halaman — jadi navbar tampil konsisten di semua view.
/// </summary>
public class NavbarViewComponent : ViewComponent
{
    private readonly IPortfolioService _portfolio;

    public NavbarViewComponent(IPortfolioService portfolio) => _portfolio = portfolio;

    public IViewComponentResult Invoke()
    {
        var culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        var nav = _portfolio.GetPortfolio(culture).Nav;
        return View(nav);
    }
}
