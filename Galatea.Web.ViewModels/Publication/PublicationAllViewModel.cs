using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Galatea.Web.ViewModels.Publication
{
    public class PublicationAllViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;

        [Display(Name = "Снимка")]
        public string? ImageUrl { get; set; }
    }
}
