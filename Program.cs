using Microsoft.AspNetCore.Localization;
using PortofolioASP.Services;

var builder = WebApplication.CreateBuilder(args);

// MVC (Controllers + Views).
builder.Services.AddControllersWithViews();

// --- Application services (Dependency Injection) ---
// Konten portfolio dibaca dari JSON & di-cache -> Singleton.
builder.Services.AddSingleton<IPortfolioService, PortfolioService>();
// Pengiriman email form kontak.
builder.Services.AddScoped<IEmailService, SmtpEmailService>();
// Bind konfigurasi SMTP dari section "Email" di appsettings.
builder.Services.Configure<EmailOptions>(builder.Configuration.GetSection(EmailOptions.SectionName));

// --- Localization (disiapkan; English default dulu) ---
// Untuk menambah bahasa: tambah file Data/portfolio.{culture}.json + masukkan culture di list bawah.
var supportedCultures = new[] { "en" }; // nanti: "id", "ja"
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.SetDefaultCulture("en");
    options.AddSupportedCultures(supportedCultures);
    options.AddSupportedUICultures(supportedCultures);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseRequestLocalization();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
