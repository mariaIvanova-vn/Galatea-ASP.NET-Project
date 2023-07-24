using Galatea.Web.ViewModels.Publication.Enum;
using System.ComponentModel.DataAnnotations;

using static Galatea.Common.EntityValidationConstants.PublicationsQuery;
using static Galatea.Common.GeneralConstants;

namespace Galatea.Web.ViewModels.Publication
{
    public class PublicationsAllQueryModel
    {
        public PublicationsAllQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.PublicationsPerPage = DefaultPublicationPerPage;

            this.Categories = new HashSet<string>();
            this.Publications = new HashSet<PublicationAllViewModel>();
        }
        [Display(Name = "Категория")]
        public string? Category { get; set; }


        [MaxLength(SearchMaxLength)]
        [Display(Name = "Търсене")]
        public string? SearchTerm { get; set; }

        [Display(Name = "Подреди публикациите по")]
        public PublicationSorting PublicationSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Публикации на страница")]
        public int PublicationsPerPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<PublicationAllViewModel> Publications { get; set; }
    }
}
