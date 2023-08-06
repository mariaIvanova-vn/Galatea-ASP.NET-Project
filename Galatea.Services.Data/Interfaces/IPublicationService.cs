
using Galatea.Services.Data.PublicationServiceModel;
using Galatea.Services.Data.Statistics;
using Galatea.Web.ViewModels.Publication;


namespace Galatea.Services.Data.Interfaces
{
    public interface IPublicationService
    {

        Task<string> CreateAndReturnIdAsync(PublicationFormModel model, string userId);

        Task<AllPublicationFilteredServiceModel> AllAsync(PublicationsAllQueryModel model);

        Task<IEnumerable<PublicationAllViewModel>> AllByUserIdAsync(string userId);

        Task<PublicationDetails> GetDetailsByIdAsync(string publicationId);

        Task<bool> ExistByIdAsync(string publicationId);

        //Task<bool> IsUserWithIdOwnerOfPublicationWithIdAsync(string publicationId, string userId);

        Task<PublicationFormModel> GetPublicationForEditAsync(string publicationId);

        Task EditPublicationByIdAsync(string publicationId, PublicationFormModel formModel);

        Task<PublicationDeleteDetailsViewModel> GetPublicationForDeleteAsync(string publicationId);

        Task DeletePublicationByIdAsync(string publicationId);

        Task<bool> IsUserPublicationOwnerAsync(string publicationId, string userId);

        Task<StatisticsServiceModel> GetStatisticsAsync();
    }
}
