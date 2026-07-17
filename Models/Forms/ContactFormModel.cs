using System.ComponentModel.DataAnnotations;

namespace PortofolioASP.Models.Forms;

/// <summary>
/// Model binding + validasi untuk form kontak (server-side).
/// Divalidasi lewat ModelState di ContactController.
/// </summary>
public class ContactFormModel
{
    [Required(ErrorMessage = "Please enter your name.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be 2–100 characters.")]
    [Display(Name = "Name")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter your email.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a message.")]
    [StringLength(2000, MinimumLength = 10, ErrorMessage = "Message must be 10–2000 characters.")]
    [Display(Name = "Message")]
    public string Message { get; set; } = string.Empty;
}
