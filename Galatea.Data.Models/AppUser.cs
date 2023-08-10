using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Galatea.Common.EntityValidationConstants.AppUser;

namespace Galatea.Data.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public AppUser()
        {
            this.Id = Guid.NewGuid();

            this.UsersPublications = new HashSet<Publication>();

            this.GivenRatings = new HashSet<Rating>();
            this.UserResponses = new HashSet<UserResponse>();
            this.CommentsPublications = new HashSet<Comment>();
        }

        //[Required]
        //[MaxLength(FirstNameMaxLength)]
        //public string FirstName { get; set; } = null!;

        //[Required]
        //[MaxLength(LastNameMaxLength)]
        //public string LastName { get; set; } = null!;


        //public bool IsDeleted { get; set; }

        //public DateTime? DeletedOn { get; set; }

        //public string ProfilePictureUrl { get; set; } = "/images/avatar.png";

        //public string City { get; set; } = null!;

        //public string Address { get; set; } = null!;
        //public Gender Gender { get; set; }


        public virtual ICollection<Publication> UsersPublications { get; set; }

        public virtual ICollection<Comment> CommentsPublications { get; set; }

        public virtual ICollection<UserResponse> UserResponses { get; set; }

        public virtual ICollection<Rating> GivenRatings { get; set; }
    }
}