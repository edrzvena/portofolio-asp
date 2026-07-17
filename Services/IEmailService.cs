using PortofolioASP.Models.Forms;

namespace PortofolioASP.Services;

/// <summary>Mengirim pesan dari form kontak.</summary>
public interface IEmailService
{
    /// <summary>Kirim pesan kontak. Melempar exception jika gagal.</summary>
    Task SendContactAsync(ContactFormModel message, CancellationToken cancellationToken = default);
}
