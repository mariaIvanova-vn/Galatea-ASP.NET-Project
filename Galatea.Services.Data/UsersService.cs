using Galatea.Data.Models;
using Galatea.Services.Data.Interfaces;
using Galatea.Services.Data.PublicationServiceModel;
using Galatea.Web.Data;
using Galatea.Web.ViewModels.Comments;
using Galatea.Web.ViewModels.Publication;
using Galatea.Web.ViewModels.Publication.Enum;
using Galatea.Web.ViewModels.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using static Galatea.Common.EntityValidationConstants;
using Publication = Galatea.Data.Models.Publication;

namespace Galatea.Services.Data
{
    public class UsersService : IUsersService
    {
        private readonly GalateaDbContext dbContext;

        public UsersService(GalateaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> GetUser(string id)
        {
            var user = await this.dbContext.Users
                .FirstAsync(h => h.Id.ToString() == id);

            return user.UserName;
        }

        public int GetUserCount()
        {
            var userCount =
                this.dbContext.Users.AsNoTracking().Count();
                              
            return userCount;
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
                .Where(p => p.IsActive)
                .FirstAsync(p => p.Id.ToString() == publicationId);

            return publication.UserId.ToString() == userId;
        }
    }
}
