using System.Collections.Generic;
using MyStorage.Core.Dtos.Stock;

namespace MyStorage.Core.Dtos.Supplier
{
    public class SupplierDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }  
        
        public IEnumerable<StockDto> Stocks { set; get; }                         
    }
}