using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Galatea.Common.EntityValidationConstants.Comment;

namespace Galatea.Data.Models
{
    public class Comment
    {
        public Comment()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TextMaxLength)]
        public string Text { get; set; } = null!;


        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual AppUser User { get; set; } = null!;

        public Guid PublicationId { get; set; }

        [ForeignKey(nameof(PublicationId))]
        public virtual Publication Publication { get; set; } = null!;


    }
}
