using Galatea.Data.Models;
using Galatea.Services.Data;
using Galatea.Services.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Galatea.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        private readonly IUsersService userService;
        private readonly ICommentsService commentService;
        public UsersController(UserManager<AppUser> userManager, IUsersService userService, ICommentsService commentService)
        {
            this.userManager = userManager;
            this.userService = userService;
            this.commentService = commentService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
