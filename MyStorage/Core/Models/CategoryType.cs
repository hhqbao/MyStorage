using System.Collections.Generic;

namespace MyStorage.Core.Models
{
    public class CategoryType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}