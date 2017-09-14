namespace MyStorage.Core.Models
{
    public enum ChangeType
    {
        Create = 1,
        Update = 2,
        Remove = 3
    }

    public class StockChange
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int ProductId { get; set; }
        public double NewQuantity { get; set; }
        public bool IsRead { get; set; }
        public ChangeType ChangeType { get; set; }

        public StockChange()
        {
            
        }

        private StockChange(Stock stock)
        {
            SupplierId = stock.SupplierId;
            ProductId = stock.ProductId;
        }

        public static StockChange CreatedChange(Stock stock)
        {
            var change = new StockChange(stock)
            {
                ChangeType = ChangeType.Create
            };

            return change;
        }

        public static StockChange UpdatedChange(Stock stock)
        {
            var change = new StockChange(stock)
            {
                NewQuantity = stock.Quantity,
                ChangeType = ChangeType.Update
            };

            return change;
        }

        public static StockChange RemovedChange(Stock stock)
        {
            var change = new StockChange(stock)
            {
                ChangeType = ChangeType.Remove
            };

            return change;
        }

        public void Read()
        {
            IsRead = true;
        }
    }
}