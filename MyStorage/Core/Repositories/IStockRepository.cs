using MyStorage.Core.Models;
using System.Collections.Generic;

namespace MyStorage.Core.Repositories
{
    public interface IStockRepository : IRepository<Stock>
    {
        IEnumerable<Stock> GetStocksWithProduct();
        Stock GetStock(int id);
        Stock GetStockWithProductAndSupplier(int stockId);
    }
}