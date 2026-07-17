using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using PortofolioASP.Models.Forms;
using PortofolioASP.Models.ViewModels;
using PortofolioASP.Services;

namespace PortofolioASP.Controllers;

public class ContactController : Controller
{
    private readonly IEmailService _email;
    private readonly IPortfolioService _portfolio;
    private readonly ILogger<ContactController> _logger;

    public ContactController(IEmailService email, IPortfolioService portfolio, ILogger<ContactController> logger)
    {
        _email = email;
        _portfolio = portfolio;
        _logger = logger;
    }

    // Form kontak posting ke sini. Prefix "Form" cocok dengan asp-for="Form.*" di partial _Contact.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Send([Bind(Prefix = "Form")] ContactFormModel form)
    {
        // Validasi gagal: render ulang halaman penuh supaya error per-field & input tetap muncul.
        if (!ModelState.IsValid)
        {
            var culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var model = new HomePageViewModel
            {
                Portfolio = _portfolio.GetPortfolio(culture),
                ContactForm = form,
                Status = ContactStatus.None,
            };
            ViewData["ScrollToContact"] = true;
            return View("~/Views/Home/Index.cshtml", model);
        }

        // Valid: kirim email, lalu redirect (pola Post/Redirect/Get) + status via TempData.
        try
        {
            await _email.SendContactAsync(form);
            TempData["ContactStatus"] = nameof(ContactStatus.Success);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to send contact message from {Email}.", form.Email);
            TempData["ContactStatus"] = nameof(ContactStatus.Error);
        }

        return RedirectToAction("Index", "Home", fragment: "contact");
    }
}
