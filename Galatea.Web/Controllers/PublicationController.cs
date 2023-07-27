using Galatea.Services.Data;
using Galatea.Services.Data.Interfaces;
using Galatea.Services.Data.PublicationServiceModel;
using Galatea.Web.ViewModels.Publication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

using static Galatea.Common.NotificationMessages;

namespace Galatea.Web.Controllers
{
    [Authorize]
    public class PublicationController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IPublicationService _publicationService;
        private readonly IUserService _userService;

        public PublicationController(ICategoryService categoryService, IPublicationService publicationService, IUserService userService)
        {
            this._categoryService = categoryService;
            this._publicationService = publicationService;
            this._userService = userService;
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
            PublicationFormModel formModel = new PublicationFormModel()
            {
                Categories = await _categoryService.GetAllCategoriesAsync()
            };

            return View(formModel);
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
                string publicationId =
                   await _publicationService.CreateAsync(formModel);
                
                return RedirectToAction("Details", "Publication", new { id = publicationId });             
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Неочаквана грешка при добавянето на обява. Моля опитайте по-късно!");
                formModel.Categories = await _categoryService.GetAllCategoriesAsync();
                return View(formModel);
            }            
            //return RedirectToAction("All", "Publication");
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
            string? userId =
               await _userService.GetUserIdAsync();

            bool isUserOwner = await _publicationService
                .IsUserWithIdOwnerOfPublicationWithIdAsync(id, userId!);
            if (!isUserOwner)
            {
                return this.NotFound();
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
            string? userId =
               await _userService.GetUserIdAsync();

            bool isUserOwner = await _publicationService
                .IsUserWithIdOwnerOfPublicationWithIdAsync(id, userId!);
            if (!isUserOwner)
            {
                TempData[ErrorMessage] = "Трябва публикацията да е ваша за да я редактирате!";

                return RedirectToAction("All", "Publication");
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
            string? userId =
               await _userService.GetUserIdAsync();
               
            bool isUserOwner = await _publicationService
                .IsUserWithIdOwnerOfPublicationWithIdAsync(id, userId!);
            if (!isUserOwner)
            {
                TempData[ErrorMessage] = "Трябва публикацията да е ваша за да я изтриете!";

                return RedirectToAction("All", "Publication");
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
            string? userId =
               await _userService.GetUserIdAsync();

            bool isUserOwner = await _publicationService
                .IsUserWithIdOwnerOfPublicationWithIdAsync(id, userId!);
            if (!isUserOwner)
            {
                TempData[ErrorMessage] = "Трябва публикацията да е ваша за да я изтриете!";

                return RedirectToAction("All", "Publication");
            }

            try
            {
                await _publicationService.DeletePublicationByIdAsync(id);

                TempData[WarningMessage] = "Публикацията беше изтрита успешно!";
                return RedirectToAction("MyPublication", "Publication");
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
