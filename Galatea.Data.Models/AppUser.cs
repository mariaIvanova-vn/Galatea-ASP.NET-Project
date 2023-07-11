using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

using static Galatea.Common.EntityValidationConstants.AppUser;

namespace Galatea.Data.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public AppUser()
        {
            this.UsersPublications = new HashSet<Publication>();
            this.GivenRatings = new HashSet<Rating>();
            this.UserResponses = new HashSet<UserResponse>();
        }
        //[Required]
        //[MaxLength(FirstNameMaxLength)]
        //public string FirstName { get; set; } = null!;

        //[Required]
        //[MaxLength(LastNameMaxLength)]
        //public string LastName { get; set; } = null!;

        //public Gender Gender { get; set; }


        public virtual ICollection<Publication> UsersPublications { get; set; }

        public virtual ICollection<UserResponse> UserResponses { get; set; }

        public virtual ICollection<Rating> GivenRatings { get; set; }
    }
}
