using MyStorage.Core.Models;
using MyStorage.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyStorage.Persistent.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Supplier GetSupplier(int id)
        {
            return Context.Suppliers.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            return Context.Suppliers
                .ToList();
        }

        public IEnumerable<Supplier> GetSuppliersWithProducts()
        {
            return Context.Suppliers
                .Include(s => s.Stocks.Select<Stock, Product>(st => st.Product))                
                .ToList();
        }
    }
}