using Galatea.Web.ViewModels.Publication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galatea.Services.Data.Models.Publication
{
    public class AllPublicationFilteredServiceModel
    {
        public AllPublicationFilteredServiceModel()
        {
            this.Publications = new HashSet<PublicationAllViewModel>();
        }

        public int TotalPublications { get; set; }

        public IEnumerable<PublicationAllViewModel> Publications { get; set; }
    }
}
