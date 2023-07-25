using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Galatea.Data.Models
{
    public class UserResponse
    {
        [Key]
        public int Id { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual AppUser User { get; set; } = null!;


        public Guid ResponseId { get; set; }

        [ForeignKey(nameof(ResponseId))]
        public virtual Response Response { get; set; } = null!;
    }
}