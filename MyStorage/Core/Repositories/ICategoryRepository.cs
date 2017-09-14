using MyStorage.Core.Models;
using System.Collections.Generic;

namespace MyStorage.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCategoryWithTypes(int id);
        IEnumerable<Category> GetCategories();
    }
}