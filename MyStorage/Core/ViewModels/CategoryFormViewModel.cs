using System.ComponentModel.DataAnnotations;
using MyStorage.Core.Models;

namespace MyStorage.Core.ViewModels
{
    public class CategoryFormViewModel
    {        
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public CategoryFormViewModel()
        {
            
        }

        public CategoryFormViewModel(Category category)
        {
            Id = category.Id;
            Name = category.Name;
        }
    }
}