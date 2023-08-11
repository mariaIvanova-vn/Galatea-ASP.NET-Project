using Galatea.Web.ViewModels.Category;
using System.ComponentModel.DataAnnotations;

using static Galatea.Common.EntityValidationConstants.Publication;

namespace Galatea.Web.ViewModels.Publication
{
    public class PublicationFormModel
    {
        public PublicationFormModel()
        {
            this.Categories = new HashSet<CategoryPublicationSelectFormModel>();
        }

        [Required(ErrorMessage = "Заглавие е задължително")]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Съдържание е задължително")]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        [Display(Name = "Съдържание")]
        public string Content { get; set; } = null!;

        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength)]
        [Display(Name = "Снимка")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Категория")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryPublicationSelectFormModel> Categories { get; set; }
    }
}
