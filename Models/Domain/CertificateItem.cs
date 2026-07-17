namespace PortofolioASP.Models.Domain;

/// <summary>Satu kartu sertifikat.</summary>
public class CertificateItem
{
    public string Title { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string VerifyUrl { get; set; } = string.Empty;
}
