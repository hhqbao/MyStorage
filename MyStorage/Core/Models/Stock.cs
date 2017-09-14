using MyStorage.Core.Dtos.Stock;

namespace MyStorage.Core.Models
{
    public class Stock
    {
        public int Id { get; private set; }

        public int SupplierId { get; private set; }

        public int ProductId { get; private set; }

        public string StockCode { get; private set; }

        public string BarCode { get; private set; }

        public double Quantity { get; private set; }

        public Supplier Supplier { get; private set; }
        public Product Product { get; private set; }

        public Stock() { }

        public Stock(StockDto viewModel)
        {
            SupplierId = viewModel.SupplierId;
            ProductId = viewModel.ProductId;
            StockCode = viewModel.StockCode;
            BarCode = viewModel.BarCode;
            Quantity = viewModel.Quantity;
        }

        public void UpdateQuantity(int quantity, bool sendMessage)
        {
            this.Quantity = quantity;

            if (Quantity <= 3 && sendMessage)
            {
                var toPhone = "+61408633929";
                var message = "==========\n" + Supplier.Name + "\n" + Product.Name + " - Hết rồi!!!";

                new TwilioLibrary(toPhone, message).SendSMS();
            }
        }
    }
}