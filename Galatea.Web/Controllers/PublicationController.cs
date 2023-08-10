using Galatea.Data.Models;
using Galatea.Services.Data;
using Galatea.Services.Data.Interfaces;
using Galatea.Services.Data.PublicationServiceModel;
using Galatea.Web.ViewModels.Comments;
using Galatea.Web.ViewModels.Publication;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;

using static Galatea.Common.NotificationMessages;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Galatea.Web.Controllers
{
    [Authorize]
    public class PublicationController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IPublicationService _publicationService;
        private readonly ICommentsService _commentsService;
        private readonly IUsersService _userService;
        private readonly UserManager<AppUser> userManager;

        public PublicationController(ICategoryService categoryService, IPublicationService publicationService, IUsersService userService, UserManager<AppUser> userManager, ICommentsService commentsService)
        {
            this._categoryService = categoryService;
            this._publicationService = publicationService;
            this._userService = userService;
            this.userManager = userManager;
            this._commentsService = commentsService; 

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] PublicationsAllQueryModel queryModel)
        {
            AllPublicationFilteredServiceModel serviceModel =
               await this._publicationService.AllAsync(queryModel);

            queryModel.Publications = serviceModel.publications;
            queryModel.PublicationsPerPage = serviceModel.TotalPublicationsCount;
            queryModel.Categories = await _categoryService.AllCategoryNamesAsync();

            return this.View(queryModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                PublicationFormModel formModel = new PublicationFormModel()
                {
                    Categories = await _categoryService.GetAllCategoriesAsync()
                };

                return View(formModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Грешка при добавянето на публикация. Моля опитайте по-късно!");

                return RedirectToAction("Index", "Home");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Add(PublicationFormModel formModel)
        {
            bool categoryExist = await _categoryService.ExistIdAsync(formModel.CategoryId);
            if (!categoryExist)
            {
                ModelState.AddModelError(nameof(formModel.CategoryId), "Избраната категория не съществува!");
            }

            if (!ModelState.IsValid)
            {
                formModel.Categories = await _categoryService.GetAllCategoriesAsync();
                return View(formModel);
            }
            try
            {
                var user = await this.userManager.GetUserAsync(this.User);
                var id = await this._publicationService.CreateAndReturnIdAsync(formModel, user.Id.ToString());
                         
                return this.RedirectToAction("Details", new { id = id });
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Неочаквана грешка при добавянето на обява. Моля опитайте по-късно!");
                formModel.Categories = await _categoryService.GetAllCategoriesAsync();
                return RedirectToAction("Index", "Home");
            }            
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool isPublicationExist = await _publicationService.ExistByIdAsync(id);
            if (!isPublicationExist)
            {
                return this.NotFound();
            }

            try
            {
                PublicationDetails publicationDetails = await _publicationService.GetDetailsByIdAsync(id);

                //var comments = await this._commentsService.GetCommentByUserIdAsync(id);
                //publicationDetails.Comments = (IEnumerable<CommentViewModel>)comments;
                   
                return View(publicationDetails);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Грешка при достъпването на детайлите. Моля опитайте по-късно!");

                return RedirectToAction("Index", "Home");
            }            
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool isPublicationExist = await _publicationService.ExistByIdAsync(id);
            if (!isPublicationExist)
            {
                return this.NotFound();
            }
            var user = await this.userManager.GetUserAsync(this.User);
            string? userId = user.Id.ToString();          
            bool isUserOwner = await _publicationService.IsUserPublicationOwnerAsync(id, userId!);
            if (!isUserOwner)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                PublicationFormModel formModel = await _publicationService
                    .GetPublicationForEditAsync(id);
                formModel.Categories = await _categoryService.GetAllCategoriesAsync();

                return View(formModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Грешка при достъпването на детайлите. Моля опитайте по-късно!");

                return RedirectToAction("Index", "Home");
            }           
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, PublicationFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                formModel.Categories = await _categoryService.GetAllCategoriesAsync();

                return View(formModel);
            }

            bool isPublicationExist = await _publicationService.ExistByIdAsync(id);
            if (!isPublicationExist)
            {
                return this.NotFound();
            }
            var user = await this.userManager.GetUserAsync(this.User);
            string? userId = user.Id.ToString();
            bool isUserOwner = await _publicationService.IsUserPublicationOwnerAsync(id, userId!);
            if (!isUserOwner)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                await _publicationService.EditPublicationByIdAsync(id, formModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Грешка при редактирането на публикация. Моля опитайте по-късно!");
                formModel.Categories = await _categoryService.GetAllCategoriesAsync();
                return View(formModel);
            }                      
            return RedirectToAction("Details", "Publication", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool isPublicationExist = await _publicationService.ExistByIdAsync(id);
            if (!isPublicationExist)
            {
                return this.NotFound();
            }
            var user = await this.userManager.GetUserAsync(this.User);
            string? userId = user.Id.ToString();
            bool isUserOwner = await _publicationService.IsUserPublicationOwnerAsync(id, userId!);
            if (!isUserOwner)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                PublicationDeleteDetailsViewModel viewModel =
                    await _publicationService.GetPublicationForDeleteAsync(id);
                return View(viewModel);
            }
            catch (Exception)
            {
                return this.NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, PublicationDeleteDetailsViewModel model)
        {
            bool isPublicationExist = await _publicationService.ExistByIdAsync(id);
            if (!isPublicationExist)
            {
                return this.NotFound();
            }
            var user = await this.userManager.GetUserAsync(this.User);
            string? userId = user.Id.ToString();
            bool isUserOwner = await _publicationService.IsUserPublicationOwnerAsync(id, userId!);
            if (!isUserOwner)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                await _publicationService.DeletePublicationByIdAsync(id);

                TempData[WarningMessage] = "Публикацията беше изтрита успешно!";
                return RedirectToAction("MyPublications", "Publication");
            }
            catch (Exception)
            {
                return this.NotFound();
            }
        }


        [HttpGet]
        public async Task<IActionResult> MyPublications()
        {
            var myPublication = new List<PublicationAllViewModel>();

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            myPublication.AddRange(await _publicationService.AllByUserIdAsync(userId));

            return View(myPublication);
        }
    }
}
