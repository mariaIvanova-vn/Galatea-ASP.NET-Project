using Galatea.Web.ViewModels.Comments;
using Galatea.Web.ViewModels.Publication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galatea.Services.Data.CommentServiceModel
{
    public class AllCommentFilteredServiceModel
    {
        public AllCommentFilteredServiceModel()
        {
            this.comments = new HashSet<CommentViewModel>();
        }

        public int TotalCommentsCount { get; set; }

        public IEnumerable<CommentViewModel> comments { get; set; }
    }
}
