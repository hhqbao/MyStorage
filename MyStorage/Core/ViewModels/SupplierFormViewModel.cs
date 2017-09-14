using System.ComponentModel.DataAnnotations;
using MyStorage.Core.Models;

namespace MyStorage.Core.ViewModels
{
    public class SupplierFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(255)]
        [RegularExpression(@"^([0-9]{8,10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Phone { get; set; }

        public SupplierFormViewModel()
        {
            
        }

        public SupplierFormViewModel(Supplier supplier)
        {
            Id = supplier.Id;
            Name = supplier.Name;
            Phone = supplier.Phone;
        }
    }
}