using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galatea.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<string?> GetUserIdAsync();

        Task<bool> IsUserWithIdOwnerOfPublicationWithIdAsync(string publicationId, string userId);
    }
}
