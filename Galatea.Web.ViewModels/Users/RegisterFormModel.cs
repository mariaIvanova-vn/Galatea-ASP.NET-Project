using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Galatea.Web.ViewModels.Users
{
    public class RegisterFormModel
    {
        [Required(ErrorMessage = "Имейл e задължително")]
        [EmailAddress(ErrorMessage = "Невалиден имейл ")]
        [Display(Name = "Имейл")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Парола e задължително")]
        [StringLength(20, ErrorMessage = " {0} най-малко {2} най-много {1} символа.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Потвърди парола e задължително")]
        [DataType(DataType.Password)]
        [Display(Name = "Потвърди парола")]
        [Compare("Password", ErrorMessage = "Двете пароли не съвпадат")]
        public string ConfirmPassword { get; set; } = null!;

        //[Required(ErrorMessage = "Първо име e задължително")]
        //[Display(Name = "Първо име")]
        //[StringLength(20, ErrorMessage = " {0} най-малко {2} най-много {1} символа.", MinimumLength = 2)]
        //public string FirstName { get; set; } = null!;

        //[Required(ErrorMessage = "Фамилия e задължително")]
        //[Display(Name = "Фамилия")]
        //[StringLength(20, ErrorMessage = " {0} най-малко {2} най-много {1} символа.", MinimumLength = 2)]
        //public string LastName { get; set; } = null!;
    }
}
