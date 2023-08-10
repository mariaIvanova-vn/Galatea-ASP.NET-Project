using Galatea.Data.Models;
using Galatea.Web.ViewModels.Comments;
using Galatea.Web.ViewModels.Publication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galatea.Web.ViewModels.Users
{
    public class UserViewModel 
    {
        public UserViewModel()
        {
            this.Publications = new HashSet<PublicationFormModel>();
            this.Comments = new HashSet<CommentViewModel>();
        }

        public string Id { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;       

        public virtual ICollection<PublicationFormModel> Publications { get; set; } 

        public virtual ICollection<CommentViewModel> Comments { get; set; } 

        //public virtual ICollection<UserOpinion> UserOpinions { get; set; }

        //public virtual ICollection<Photo> Photos { get; set; }
    }
}
