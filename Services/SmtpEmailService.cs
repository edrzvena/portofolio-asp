using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using PortofolioASP.Models.Forms;

namespace PortofolioASP.Services;

/// <summary>
/// Implementasi <see cref="IEmailService"/> berbasis SMTP.
/// Jika Host belum dikonfigurasi (mis. saat development), pesan hanya di-log ke console
/// sehingga form tetap bisa dites tanpa kredensial email.
/// </summary>
public class SmtpEmailService : IEmailService
{
    private readonly EmailOptions _options;
    private readonly ILogger<SmtpEmailService> _logger;

    public SmtpEmailService(IOptions<EmailOptions> options, ILogger<SmtpEmailService> logger)
    {
        _options = options.Value;
        _logger = logger;
    }

    public async Task SendContactAsync(ContactFormModel message, CancellationToken cancellationToken = default)
    {
        // Mode dev: tidak ada SMTP host, cukup catat ke log.
        if (string.IsNullOrWhiteSpace(_options.Host))
        {
            _logger.LogInformation(
                "[DEV email] Contact message received (not sent — no SMTP host configured).\n" +
                "From: {Name} <{Email}>\nMessage: {Message}",
                message.Name, message.Email, message.Message);
            return;
        }

        using var mail = new MailMessage
        {
            From = new MailAddress(_options.FromAddress, _options.FromName),
            Subject = $"Portfolio contact from {message.Name}",
            Body = $"Name: {message.Name}\nEmail: {message.Email}\n\n{message.Message}",
            IsBodyHtml = false,
        };
        mail.To.Add(_options.ToAddress);

        // ReplyTo diisi email pengirim supaya bisa langsung dibalas.
        mail.ReplyToList.Add(new MailAddress(message.Email, message.Name));

        using var client = new SmtpClient(_options.Host, _options.Port)
        {
            EnableSsl = _options.UseSsl,
            Credentials = string.IsNullOrEmpty(_options.Username)
                ? CredentialCache.DefaultNetworkCredentials
                : new NetworkCredential(_options.Username, _options.Password),
        };

        await client.SendMailAsync(mail, cancellationToken);
        _logger.LogInformation("Contact message from {Email} sent successfully.", message.Email);
    }
}
