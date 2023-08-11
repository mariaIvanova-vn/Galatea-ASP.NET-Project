using Galatea.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;

using Galatea.Services.Data.Interfaces;
using Galatea.Data.Models;
using Galatea.Web.Areas.Admin.Models;
using Galatea.Services.Data;
using Galatea.Web.ViewModels.Publication;
using System.Security.Claims;

namespace Galatea.Web.Areas.Admin.Controllers
{
    public class PublicationController : BaseAdminController
    {
        private readonly IUsersService usersService;
        private readonly IPublicationService publicationService;

        public PublicationController(IUsersService usersService, IPublicationService publicationService)
        {
            this.usersService = usersService;
            this.publicationService = publicationService;
        }

        public async Task<IActionResult> Mine()
        {
            string? userId =
                         await this.usersService.GetUserIdAsync();
            MyPublicationViewModel viewModel = new MyPublicationViewModel()
            {
                AddedPublication = await this.publicationService.AllByUserIdAsync(userId!),
            };

            return this.View(viewModel);
        }
    }
}
