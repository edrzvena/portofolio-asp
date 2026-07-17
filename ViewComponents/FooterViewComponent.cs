using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using PortofolioASP.Services;

namespace PortofolioASP.ViewComponents;

/// <summary>Merender footer dengan datanya sendiri dari IPortfolioService.</summary>
public class FooterViewComponent : ViewComponent
{
    private readonly IPortfolioService _portfolio;

    public FooterViewComponent(IPortfolioService portfolio) => _portfolio = portfolio;

    public IViewComponentResult Invoke()
    {
        var culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        var footer = _portfolio.GetPortfolio(culture).Footer;
        return View(footer);
    }
}
