using MyStorage.Core.Models;
using MyStorage.Persistent.Repositories;

namespace MyStorage.Core.Repositories
{
    public interface ICategoryTypeRepository : IRepository<CategoryType>
    {
        CategoryType GetCategoryType(int id);
    }
}