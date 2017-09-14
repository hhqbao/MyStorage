using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoMapper;
using MyStorage.Core.Dtos.Product;

namespace MyStorage.Core.Models
{
    public class Product
    {
        public int Id { get; set; }        
        public string Name { get; set; }                               

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int? CategoryTypeId { get; set; }
        public CategoryType CategoryType { get; set; }
        public ICollection<Stock> Stocks { get; set; }

        public Product()
        {            
            Stocks = new Collection<Stock>();
        }

        public void Update(ProductDto viewModel)
        {
            Mapper.Map(viewModel, this);            
        }        
    }
}