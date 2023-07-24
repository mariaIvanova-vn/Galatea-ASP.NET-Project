
using Galatea.Data.Models;
using Galatea.Services.Data.Interfaces;
using Galatea.Services.Data.PublicationServiceModel;
using Galatea.Web.Data;
using Galatea.Web.ViewModels.Comments;
using Galatea.Web.ViewModels.Publication;
using Galatea.Web.ViewModels.Publication.Enum;
using Microsoft.EntityFrameworkCore;

namespace Galatea.Services.Data
{
    public class PublicationService : IPublicationService
    {
        private readonly GalateaDbContext dbContext;

        public PublicationService(GalateaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AllPublicationFilteredServiceModel> AllAsync(PublicationsAllQueryModel model)
        {
            IQueryable<Publication> publicationsQuery = this.dbContext
                .Publications
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.Category))
            {
                publicationsQuery = publicationsQuery
                    .Where(h => h.Category.Name == model.Category);
            }

            if (!string.IsNullOrWhiteSpace(model.SearchTerm))
            {
                string wildCard = $"%{model.SearchTerm.ToLower()}%";

                publicationsQuery = publicationsQuery
                    .Where(h => EF.Functions.Like(h.Title, wildCard) ||
                                EF.Functions.Like(h.Content, wildCard));
            }

            publicationsQuery = model.PublicationSorting switch
            {
                PublicationSorting.Newest => publicationsQuery
                    .OrderByDescending(p => p.CreatedOn),
                PublicationSorting.Oldest => publicationsQuery
                    .OrderBy(p => p.CreatedOn),
                PublicationSorting.TitleNameAscending => publicationsQuery
                    .OrderBy(t => t.Title),
                PublicationSorting.TitleNameDescending => publicationsQuery
                    .OrderByDescending(t => t.Title),
                _ => publicationsQuery
                .OrderByDescending(p => p.CreatedOn)
            };

            IEnumerable<PublicationAllViewModel> publicationss = await publicationsQuery
                .Where(p=>p.IsActive)
                .Skip((model.CurrentPage - 1) * model.PublicationsPerPage)
                .Take(model.PublicationsPerPage)
                .Select(p => new PublicationAllViewModel
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    Content = p.Content,
                    ImageUrl = p.ImageUrl,                  
                })
                .ToArrayAsync();
            int totalPublication = publicationsQuery.Count();

            return new AllPublicationFilteredServiceModel()
            {
                TotalPublicationsCount = totalPublication,
                publications = publicationss
            };
        }

        public async Task<IEnumerable<PublicationAllViewModel>> AllByUserIdAsync(string userId)
        {
            IEnumerable<PublicationAllViewModel> allUserPublications = await this.dbContext
                .Publications.Where(p=>p.IsActive).Where(p => p.UserId.ToString() == userId)
                .Select(p => new PublicationAllViewModel
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    Content = p.Content,
                    ImageUrl = p.ImageUrl,

                }).ToArrayAsync();

            return allUserPublications;
        }

        public async Task CreateAsync(PublicationFormModel model)
        {
            Publication publication = new Publication
            {
                Title = model.Title,
                Content = model.Content,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
            };
            await dbContext.Publications.AddAsync(publication);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistByIdAsync(string publicationId)
        {
            bool result = await this.dbContext.Publications.Where(p=>p.IsActive)
                .AnyAsync(p=>p.Id.ToString() == publicationId);

            return result;
        }

        public async Task<PublicationDetails> GetDetailsByIdAsync(string publicationId)
        {
            Publication publication = await dbContext
                .Publications
                .Include(p => p.Category)
                .Where(p => p.IsActive)
                .FirstAsync(p => p.Id.ToString() == publicationId);

            return new PublicationDetails
            {
                Id = publication.Id.ToString(),
                Title = publication.Title,
                Content = publication.Content,
                ImageUrl = publication.ImageUrl,
                CreatedOn = publication.CreatedOn,
                Category = publication.Category.Name,
                
            };
        }

        public async Task<PublicationFormModel> GetPublicationForEditAsync(string publicationId)
        {
            Publication publication = await this.dbContext.Publications.Include(p => p.Category)
                .Where(p => p.IsActive).FirstAsync(p => p.Id.ToString() == publicationId);

            return new PublicationFormModel
            {
                Title = publication.Title,
                Content = publication.Content,
                ImageUrl = publication.ImageUrl,
                CategoryId = publication.CategoryId
            };
        }
    }
}
