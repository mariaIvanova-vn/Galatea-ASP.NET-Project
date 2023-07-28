
using Galatea.Web.ViewModels.Category;
using Galatea.Web.ViewModels.Publication;

namespace Galatea.Web.ViewModels.Home
{
    public class IndexViewModel
    {
        public IEnumerable<CategoryPublicationSelectFormModel> Categories { get; set; } = null!;

        

        public IEnumerable<PublicationFormModel> Publications { get; set; } = null!;

        public int AspNetUsersCount { get; set; }
    }
}
