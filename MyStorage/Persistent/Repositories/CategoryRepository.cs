using MyStorage.Core.Models;
using MyStorage.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyStorage.Persistent.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Category GetCategoryWithTypes(int id)
        {
            return Context.Categories
                .Include(c => c.CategoryTypes)
                .SingleOrDefault(c => c.Id == id && !c.IsDeleted);
        }

        public IEnumerable<Category> GetCategories()
        {
            return Context.Categories
                .Include(c => c.CategoryTypes)
                .Where(c => c.IsDeleted == false)
                .ToList();
        }
    }
}