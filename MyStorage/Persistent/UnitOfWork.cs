using MyStorage.Core;
using MyStorage.Core.Models;
using MyStorage.Core.Repositories;
using MyStorage.Persistent.Repositories;

namespace MyStorage.Persistent
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICategoryRepository Categories { get; private set; }
        public ICategoryTypeRepository CategoryTypes { get; private set; }
        public IStockChangeRepository StockChanges { get; private set; }
        public IStockRepository Stocks { get; private set; }
        public ISupplierRepository Suppliers { get; private set; }
        public IProductRepository Products { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Categories = new CategoryRepository(_context);
            CategoryTypes = new CategoryTypeRepository(_context);
            StockChanges = new StockChangeRepository(_context);
            Suppliers = new SupplierRepository(_context);
            Products = new ProductRepository(_context);
            Stocks = new StockRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}