using Galatea.Services.Mapping;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

using Galatea.Data.Models;

namespace Galatea.Web.ViewModels.Publication
{
    public class PublicationAllViewModel : IMapFrom<Data.Models.Publication>
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;

        [Display(Name = "Снимка")]
        public string? ImageUrl { get; set; }
    }
}
