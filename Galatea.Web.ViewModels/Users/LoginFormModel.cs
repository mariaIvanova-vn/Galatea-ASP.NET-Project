
using System.ComponentModel.DataAnnotations;

namespace Galatea.Web.ViewModels.Users
{
    public class LoginFormModel
    {
        [Required(ErrorMessage = "Имейл е задължително")]
        [Display(Name = "Имейл")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Парола е задължително")]
        [Display(Name = "Парола")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Запомни ме")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
