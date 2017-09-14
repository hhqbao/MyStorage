using MyStorage.Core.Models;
using System.Collections.Generic;

namespace MyStorage.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProductsWithCategoryAndType();
        Product GetProduct(int id);
        IEnumerable<Product> GetProductsByName(string name);
    }
}