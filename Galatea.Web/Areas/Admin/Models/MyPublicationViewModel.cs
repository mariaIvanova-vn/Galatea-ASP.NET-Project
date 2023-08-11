using Galatea.Web.ViewModels.Publication;

namespace Galatea.Web.Areas.Admin.Models
{
	public class MyPublicationViewModel
	{
		public IEnumerable<PublicationAllViewModel> AddedPublication { get; set; } = null!;
	}
}
