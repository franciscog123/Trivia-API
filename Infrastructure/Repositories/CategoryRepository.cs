using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly TriviaGameDBContext _context;

        public CategoryRepository(TriviaGameDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ApplicationCore.Models.Category>> GetCategoriesAsync()
        {
            List<Entities.Category> categories = await _context.Category.ToListAsync();

            return categories.Select(Mapper.Map);
        }

        public async Task<ApplicationCore.Models.Category> GetCategoryAsync(int id)
        {
            var item = await _context.Category.FindAsync(id);

            if (item is null)
                return null;

            return Mapper.Map(item);
        }

        public async Task<ApplicationCore.Models.Category> AddCategoryAsync(ApplicationCore.Models.Category category)
        {
            if(category is null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            Entities.Category entity = Mapper.Map(category);

            await _context.Category.AddAsync(entity);
            await _context.SaveChangesAsync();

            return Mapper.Map(entity);
        }

    }
}
