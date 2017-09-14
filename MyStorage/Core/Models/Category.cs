using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyStorage.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<CategoryType> CategoryTypes { get; set; }
        public ICollection<Product> Products { get; set; }

        public Category()
        {
            CategoryTypes = new Collection<CategoryType>();
            Products = new Collection<Product>();
        }
    }
}