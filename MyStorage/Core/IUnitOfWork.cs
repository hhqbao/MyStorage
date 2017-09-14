using MyStorage.Core.Repositories;

namespace MyStorage.Core
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        ICategoryTypeRepository CategoryTypes { get; }
        IStockChangeRepository StockChanges { get; }
        IStockRepository Stocks { get; }
        ISupplierRepository Suppliers { get; }
        IProductRepository Products { get; }

        void Complete();
    }
}