
using Galatea.Services.Data.Interfaces;
using Galatea.Web.Data;
using Galatea.Web.ViewModels.Category;
using Microsoft.EntityFrameworkCore;

namespace Galatea.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly GalateaDbContext _dbContext;
        public CategoryService(GalateaDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<string>> AllCategoryNamesAsync()
        {
            IEnumerable<string> allCategoryNames = await this._dbContext
                 .Categories
                 .Select(c => c.Name)
                 .ToArrayAsync();

            return allCategoryNames;
        }

        public async Task<bool> ExistIdAsync(int id)
        {
            bool result = await this._dbContext.Categories.AnyAsync(c => c.Id == id);

            return result;
        }

        public async Task<IEnumerable<CategoryPublicationSelectFormModel>> GetAllCategoriesAsync()
        {
            IEnumerable<CategoryPublicationSelectFormModel> allCategories = await this._dbContext.Categories
                .Select(c=>new CategoryPublicationSelectFormModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToArrayAsync();

            return allCategories;
        }
    }
}
