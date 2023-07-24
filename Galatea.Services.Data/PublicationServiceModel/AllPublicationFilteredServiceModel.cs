using Galatea.Web.ViewModels.Publication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galatea.Services.Data.PublicationServiceModel
{
    public class AllPublicationFilteredServiceModel
    {
        public AllPublicationFilteredServiceModel()
        {
            this.publications = new HashSet<PublicationAllViewModel>();
        }

        public int TotalPublicationsCount { get; set; }

        public IEnumerable<PublicationAllViewModel> publications { get; set; }
    }
}
