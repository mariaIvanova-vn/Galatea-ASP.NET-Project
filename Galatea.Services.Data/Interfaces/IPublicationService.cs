
using Galatea.Services.Data.PublicationServiceModel;
using Galatea.Web.ViewModels.Publication;


namespace Galatea.Services.Data.Interfaces
{
    public interface IPublicationService
    {

        Task CreateAsync(PublicationFormModel model);

        Task<AllPublicationFilteredServiceModel> AllAsync(PublicationsAllQueryModel model);

        Task<IEnumerable<PublicationAllViewModel>> AllByUserIdAsync(string userId);

        Task<PublicationDetails> GetDetailsByIdAsync(string publicationId);

        Task<bool> ExistByIdAsync(string publicationId);

        Task<PublicationFormModel> GetPublicationForEditAsync(string publicationId);
    }
}
