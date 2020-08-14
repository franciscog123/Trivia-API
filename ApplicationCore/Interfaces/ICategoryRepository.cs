using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(int id);
        Task<Category> AddCategoryAsync(Category category);
    }
}
