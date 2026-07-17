using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using PortofolioASP.Models;
using PortofolioASP.Models.ViewModels;
using PortofolioASP.Services;

namespace PortofolioASP.Controllers;

public class HomeController : Controller
{
    private readonly IPortfolioService _portfolio;

    public HomeController(IPortfolioService portfolio)
    {
        _portfolio = portfolio;
    }

    public IActionResult Index()
    {
        var culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

        var model = new HomePageViewModel
        {
            Portfolio = _portfolio.GetPortfolio(culture),
            // Status pengiriman kontak dibawa dari ContactController lewat TempData (pola PRG).
            Status = TempData["ContactStatus"] switch
            {
                nameof(ContactStatus.Success) => ContactStatus.Success,
                nameof(ContactStatus.Error) => ContactStatus.Error,
                _ => ContactStatus.None,
            },
        };

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
