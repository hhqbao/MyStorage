using MyStorage.Core.Models;
using MyStorage.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyStorage.Persistent.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IEnumerable<Product> GetProductsWithCategoryAndType()
        {
            return Context.Products
                .Include(p => p.Category)
                .Include(p => p.CategoryType)                
                .ToList();
        }

        public Product GetProduct(int id)
        {
            return Context.Products.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProductsByName(string name)
        {
            return Context.Products
                .Where(p => p.Name.Contains(name))                
                .ToList();
        }
    }
}