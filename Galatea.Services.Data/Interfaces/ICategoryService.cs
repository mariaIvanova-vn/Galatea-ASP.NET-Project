
using Galatea.Web.ViewModels.Category;

namespace Galatea.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryPublicationSelectFormModel>> GetAllCategoriesAsync();

        Task<bool> ExistIdAsync(int id);

        Task<IEnumerable<string>> AllCategoryNamesAsync();
    }
}
