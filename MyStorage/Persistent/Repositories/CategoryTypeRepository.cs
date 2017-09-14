using MyStorage.Core.Models;
using MyStorage.Core.Repositories;
using System.Linq;

namespace MyStorage.Persistent.Repositories
{
    public class CategoryTypeRepository : Repository<CategoryType>, ICategoryTypeRepository
    {
        public CategoryTypeRepository(ApplicationDbContext context) : base(context)
        {

        }

        public CategoryType GetCategoryType(int id)
        {
            return Context.CategoryTypes.SingleOrDefault(t => t.Id == id);
        }
    }
}