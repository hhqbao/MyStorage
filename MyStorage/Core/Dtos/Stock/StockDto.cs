using MyStorage.Core.Dtos.Product;
using MyStorage.Core.Dtos.Supplier;

namespace MyStorage.Core.Dtos.Stock
{
    public class StockDto
    {
        public int Id { get; set; }

        public int SupplierId { get; set; }

        public int ProductId { get; set; }

        public string StockCode { get; set; }

        public string BarCode { get; set; }

        public double Quantity { get; set; }

        public SupplierDto Supplier { get; set; }

        public ProductDto Product { get; set; }          
    }
}