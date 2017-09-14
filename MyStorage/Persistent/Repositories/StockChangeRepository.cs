using MyStorage.Core.Models;
using MyStorage.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MyStorage.Persistent.Repositories
{
    public class StockChangeRepository : Repository<StockChange>, IStockChangeRepository
    {
        public StockChangeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<StockChange> GetUnreadChanges()
        {
            return Context.StockChanges
                .Where(c => !c.IsRead)
                .ToList();
        }
    }
}