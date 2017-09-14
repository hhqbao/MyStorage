using MyStorage.Core.Models;
using MyStorage.Persistent.Repositories;
using System.Collections.Generic;

namespace MyStorage.Core.Repositories
{
    public interface IStockChangeRepository : IRepository<StockChange>
    {
        IEnumerable<StockChange> GetUnreadChanges();
    }
}