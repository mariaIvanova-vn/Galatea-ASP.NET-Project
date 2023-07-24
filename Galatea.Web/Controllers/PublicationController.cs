using Galatea.Services.Data;
using Galatea.Services.Data.Interfaces;
using Galatea.Services.Data.PublicationServiceModel;
using Galatea.Web.ViewModels.Publication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace Galatea.Web.Controllers
{
    [Authorize]
    public class PublicationController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IPublicationService _publicationService;

        public PublicationController(ICategoryService categoryService, IPublicationService publicationService)
        {
            this._categoryService = categoryService;
            this._publicationService = publicationService;
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
                await _publicationService.CreateAsync(formModel);
                return RedirectToAction("All", "Publication");
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
            PublicationDetails publicationDetails = await _publicationService.GetDetailsByIdAsync(id);


            return View(publicationDetails);
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
