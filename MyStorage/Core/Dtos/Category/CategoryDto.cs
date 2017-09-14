using System.Collections.Generic;
using MyStorage.Core.Dtos.CategoryType;
using MyStorage.Core.Dtos.Product;

namespace MyStorage.Core.Dtos.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CategoryTypeDto> CategoryTypes { set; get; }
        public IEnumerable<ProductDto> Products { get; set; }
    }
}