using System.ComponentModel.DataAnnotations;
using MyStorage.Core.Models;

namespace MyStorage.Core.ViewModels
{
    public class CategoryTypeViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public CategoryTypeViewModel()
        {
            
        }

        public CategoryTypeViewModel(CategoryType categoryType)
        {
            Id = categoryType.Id;
            Name = categoryType.Name;
            CategoryId = categoryType.CategoryId;
        }
    }
}