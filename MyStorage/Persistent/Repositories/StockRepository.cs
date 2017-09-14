using MyStorage.Core.Models;
using MyStorage.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyStorage.Persistent.Repositories
{
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        public StockRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IEnumerable<Stock> GetStocksWithProduct()
        {
            return Context.Stocks
                .Include(s => s.Product)
                .ToList();
        }

        public Stock GetStock(int id)
        {
            return Context.Stocks.SingleOrDefault(s => s.Id == id);
        }

        public Stock GetStockWithProductAndSupplier(int stockId)
        {
            return Context.Stocks
                .Include(s => s.Product)
                .Include(s => s.Supplier)
                .SingleOrDefault(s => s.Id == stockId);
        }
    }
}