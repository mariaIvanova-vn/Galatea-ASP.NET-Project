using Galatea.Data.Models;
using Galatea.Services.Data.Interfaces;
using Galatea.Services.Data.PublicationServiceModel;
using Galatea.Web.Data;
using Galatea.Web.ViewModels.Comments;
using Galatea.Web.ViewModels.Publication;
using Galatea.Web.ViewModels.Publication.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Galatea.Services.Data
{
    public class UserService : IUserService
    {
        private readonly GalateaDbContext dbContext;

        public UserService(GalateaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string?> GetUserIdAsync()
        {
            var userId = await this.dbContext.UserClaims.Select(u=>u.UserId).ToArrayAsync();

            return userId.ToString();
        }

        public async Task<bool> IsUserWithIdOwnerOfPublicationWithIdAsync(string publicationId, string userId)
        {
            Publication publication = await dbContext
                .Publications
                .Where(h => h.IsActive)
                .FirstAsync(h => h.Id.ToString() == publicationId);

            return publication.UserId.ToString() == userId;
        }
    }
}
