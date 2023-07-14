using Galatea.Services.Data.Interfaces;
using Galatea.Web.ViewModels.Publication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Galatea.Web.Controllers
{
    [Authorize]
    public class PublicationController : Controller
    {
        private readonly ICategoryService _categoryService;
        public PublicationController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return View();
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
    }
}
