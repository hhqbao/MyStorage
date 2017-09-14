using System.Collections.Generic;
using MyStorage.Core.Dtos.Category;
using MyStorage.Core.Dtos.Product;

namespace MyStorage.Core.Dtos.CategoryType
{
    public class CategoryTypeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public CategoryDto Category { get; set; }

        public ICollection<ProductDto> Products { get; set; }
    }
}