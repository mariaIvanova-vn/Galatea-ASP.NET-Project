using System.ComponentModel.DataAnnotations;

using static Galatea.Common.EntityValidationConstants.Response;

namespace Galatea.Data.Models
{
    public class Response
    {
        public Response()
        {
            this.UserResponses = new HashSet<UserResponse>();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TextMaxLength)]
        public string Text { get; set; } = null!;

        [Range(RatingMinLength,RatingMaxLength)]
        public short Rating { get; set; }

        public virtual ICollection<UserResponse> UserResponses { get; set; }
    }
}