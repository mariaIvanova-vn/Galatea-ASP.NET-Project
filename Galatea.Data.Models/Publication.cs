using Galatea.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Galatea.Common.EntityValidationConstants.Publication;

namespace Galatea.Data.Models
{
    public class Publication
    {
        public Publication()
        {
            this.Id = Guid.NewGuid();
            this.Comments = new HashSet<Comment>();
            this.Rating = new HashSet<Rating>();           
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = null!;

        [MaxLength(ImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; } = null!;

        public IEnumerable<Comment> Comments { get; set; } = null!;

        public IEnumerable<Rating> Rating { get; set; } = null!;

        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual AppUser User { get; set; } = null!;
    }
}
