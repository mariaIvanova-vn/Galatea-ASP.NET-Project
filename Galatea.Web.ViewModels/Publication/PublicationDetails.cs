using Galatea.Data.Models;
using Galatea.Web.ViewModels.Comments;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Galatea.Web.ViewModels.Publication
{
    public class PublicationDetails 
    {
        public PublicationDetails()
        {
            this.Comments = new HashSet<CommentViewModel>();
        }
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;

        [Display(Name = "Снимка")]
        public string? ImageUrl { get; set; }
        public string Category { get; set; } = null!;
        public DateTime CreatedOn { get; set; }

        public virtual AppUser User { get; set; } = null!;

        public virtual IEnumerable<CommentViewModel> Comments { get; set; } 
    }
}
