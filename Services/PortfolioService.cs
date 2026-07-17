using System.Collections.Concurrent;
using System.Text.Json;
using PortofolioASP.Models.ViewModels;

namespace PortofolioASP.Services;

/// <summary>
/// Membaca konten portfolio dari file JSON per bahasa di folder /Data
/// (mis. Data/portfolio.en.json) dan meng-cache hasilnya di memori.
/// Didaftarkan sebagai Singleton — file cukup dibaca sekali per bahasa.
/// </summary>
public class PortfolioService : IPortfolioService
{
    private const string DefaultCulture = "en";

    private readonly string _dataDirectory;
    private readonly ILogger<PortfolioService> _logger;

    // Cache per-bahasa; JSON dibaca sekali lalu dipakai ulang.
    private readonly ConcurrentDictionary<string, PortfolioViewModel> _cache = new();

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    public PortfolioService(IWebHostEnvironment env, ILogger<PortfolioService> logger)
    {
        _dataDirectory = Path.Combine(env.ContentRootPath, "Data");
        _logger = logger;
    }

    public PortfolioViewModel GetPortfolio(string culture = DefaultCulture)
    {
        if (string.IsNullOrWhiteSpace(culture))
        {
            culture = DefaultCulture;
        }

        return _cache.GetOrAdd(culture, LoadFromFile);
    }

    private PortfolioViewModel LoadFromFile(string culture)
    {
        var path = Path.Combine(_dataDirectory, $"portfolio.{culture}.json");

        // Fallback ke bahasa default kalau file bahasa yang diminta belum ada.
        if (!File.Exists(path) && culture != DefaultCulture)
        {
            _logger.LogWarning("Portfolio data for culture '{Culture}' not found, falling back to '{Default}'.",
                culture, DefaultCulture);
            path = Path.Combine(_dataDirectory, $"portfolio.{DefaultCulture}.json");
        }

        var json = File.ReadAllText(path);
        var model = JsonSerializer.Deserialize<PortfolioViewModel>(json, JsonOptions);

        if (model is null)
        {
            throw new InvalidOperationException($"Failed to deserialize portfolio data from '{path}'.");
        }

        return model;
    }
}
