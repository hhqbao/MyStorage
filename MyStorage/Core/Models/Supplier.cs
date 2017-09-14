using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MyStorage.Core.ViewModels;

namespace MyStorage.Core.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Code { get; private set; }        
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Stock> Stocks { get; set; }

        public Supplier()
        {
            Code = GetCode();  
            Stocks = new Collection<Stock>();          
        }

        public static string GetCode()
        {
            Random rand = new Random();

            string code = "";

            for (int i = 0; i < 10; i++)
            {
                code += rand.Next(0, 9).ToString();
            }

            return code;
        }

        public void Update(SupplierFormViewModel viewModel)
        {
            Name = viewModel.Name;
            Phone = viewModel.Phone;
        }
    }
}