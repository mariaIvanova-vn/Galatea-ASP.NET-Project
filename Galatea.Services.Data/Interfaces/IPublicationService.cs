
using Galatea.Services.Data.PublicationServiceModel;
using Galatea.Web.ViewModels.Publication;


namespace Galatea.Services.Data.Interfaces
{
    public interface IPublicationService
    {

        Task<string> CreateAsync(PublicationFormModel model);

        Task<AllPublicationFilteredServiceModel> AllAsync(PublicationsAllQueryModel model);

        Task<IEnumerable<PublicationAllViewModel>> AllByUserIdAsync(string userId);

        Task<PublicationDetails> GetDetailsByIdAsync(string publicationId);

        Task<bool> ExistByIdAsync(string publicationId);

        Task<bool> IsUserWithIdOwnerOfPublicationWithIdAsync(string publicationId, string userId);

        Task<PublicationFormModel> GetPublicationForEditAsync(string publicationId);

        Task EditPublicationByIdAsync(string publicationId, PublicationFormModel formModel);

        Task<PublicationDeleteDetailsViewModel> GetPublicationForDeleteAsync(string publicationId);

        Task DeletePublicationByIdAsync(string publicationId);
    }
}
