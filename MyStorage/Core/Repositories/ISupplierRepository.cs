using MyStorage.Core.Models;
using System.Collections.Generic;

namespace MyStorage.Core.Repositories
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Supplier GetSupplier(int id);
        IEnumerable<Supplier> GetSuppliers();
        IEnumerable<Supplier> GetSuppliersWithProducts();
    }
}