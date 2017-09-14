using System.ComponentModel.DataAnnotations;
using MyStorage.Core.Dtos.Category;
using MyStorage.Core.Dtos.CategoryType;

namespace MyStorage.Core.Dtos.Product
{
    public class ProductDto
    {
        public int Id { get; set; }        

        [Required]
        [StringLength(255)]
        public string Name { get; set; }                     

        public int CategoryId { get; set; }

        public int? CategoryTypeId { set; get; }
           

        public CategoryDto Category { get; set; }

        public CategoryTypeDto CategoryType { set; get; }
    }
}