namespace PortofolioASP.Services;

/// <summary>
/// Konfigurasi SMTP untuk pengiriman email, di-bind dari section "Email" di appsettings.json.
/// Kredensial sebaiknya disimpan lewat User Secrets / environment variable, bukan di appsettings.
/// </summary>
public class EmailOptions
{
    public const string SectionName = "Email";

    /// <summary>Host SMTP (mis. "smtp.gmail.com"). Kosong = mode dev (hanya di-log, tidak dikirim).</summary>
    public string? Host { get; set; }
    public int Port { get; set; } = 587;
    public bool UseSsl { get; set; } = true;

    public string? Username { get; set; }
    public string? Password { get; set; }

    /// <summary>Alamat pengirim (from).</summary>
    public string FromAddress { get; set; } = "no-reply@localhost";
    public string FromName { get; set; } = "Portfolio Contact Form";

    /// <summary>Alamat tujuan pesan kontak (inbox pemilik portfolio).</summary>
    public string ToAddress { get; set; } = "widyadharta@gmail.com";
}
