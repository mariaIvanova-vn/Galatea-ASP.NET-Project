using Galatea.Data.Models;
using Galatea.Services.Data;
using Galatea.Services.Data.CommentServiceModel;
using Galatea.Services.Data.Interfaces;
using Galatea.Services.Data.PublicationServiceModel;
using Galatea.Web.ViewModels.Comments;
using Galatea.Web.ViewModels.Publication;
using Galatea.Web.ViewModels.Users;
using Griesoft.AspNetCore.ReCaptcha;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Xunit.Sdk;

namespace Galatea.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsersService userService;
        private readonly ICommentsService commentService;

        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IMemoryCache memoryCache;

        public UserController(UserManager<AppUser> userManager, IUsersService userService, ICommentsService commentService, IMemoryCache memoryCache, SignInManager<AppUser> signInManager)
        {
            this.userService = userService;
            this.commentService = commentService;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.memoryCache = memoryCache;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateRecaptcha(Action = nameof(Register),
            ValidationFailedAction = ValidationFailedAction.ContinueRequest)]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            AppUser user = new();
            
            await userManager.SetEmailAsync(user, model.Email);
            await userManager.SetUserNameAsync(user, model.Email);

            IdentityResult result =
                await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }

            await signInManager.SignInAsync(user, false);
            //this.memoryCache.Remove(UsersCacheKey);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            LoginFormModel model = new LoginFormModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result =
                await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Грешка при влизане. Моля опитайте по-късно!");

                
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }



        [Authorize]
        public async Task<IActionResult> UserProfile(string id)
        {
            var user = await this.userService.GetUser(id);

            var userId = await this.userService.GetUserIdAsync();
            user.Comments = (ICollection<CommentViewModel>)await this.commentService.GetCommentByUserIdAsync(userId!);
  
            return this.View(user);
        }
    }
}
