using Galatea.Services.Data.Interfaces;
using Galatea.Web.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

using static Galatea.Common.GeneralConstants;

namespace Galatea.Web.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        private readonly IUsersService usersService;
        private readonly IMemoryCache memoryCache;

        public UserController(IUsersService usersService, IMemoryCache memoryCache)
        {
            this.usersService = usersService;
            this.memoryCache = memoryCache;
        }

        [Route("User/All")]
        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Client, NoStore = false)]
        public async Task<IActionResult> All()
        {
            var users =await this.usersService.AllAsync();

            if (users == null)
            {
                users = await this.usersService.AllAsync();

                MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan
                        .FromMinutes(UsersCacheDurationMinutes));

                this.memoryCache.Set(UsersCacheKey, users, cacheOptions);
            }

            return View(users);
        }
    }
}
