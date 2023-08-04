using Galatea.Web.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galatea.Services.Data.Interfaces
{
    public interface IUsersService
    {
        Task<string?> GetUserIdAsync();

        Task<bool> IsUserWithIdOwnerOfPublicationWithIdAsync(string publicationId, string userId);

        int GetUserCount();

        public Task<UserViewModel> GetUser(string id);
    }
}
