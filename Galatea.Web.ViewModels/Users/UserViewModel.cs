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
        public string Id { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string ProfilePictureUrl { get; set; } = null!;

        public Gender Gender { get; set; }

        public virtual ICollection<PublicationFormModel> Publications { get; set; } = null!;

        public virtual ICollection<CommentViewModel> Comments { get; set; } = null!;

        //public virtual ICollection<UserOpinion> UserOpinions { get; set; }

        //public virtual ICollection<Photo> Photos { get; set; }
    }
}
