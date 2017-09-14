using MyStorage.Core;
using MyStorage.Core.Models;
using MyStorage.Core.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace MyStorage.Controllers
{
    [Authorize]
    public class SuppliersController : Controller
    {        
        private readonly IUnitOfWork _unitOfWork;

        public SuppliersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public ActionResult Index()
        {
            var suppliers = _unitOfWork.Suppliers.GetSuppliers()
                .OrderBy(s => s.Name);

            return View(suppliers);
        }        

        public ActionResult Create()
        {
            return View("SupplierForm", new SupplierFormViewModel());
        }

        public ActionResult Edit(int id)
        {
            var supplier = _unitOfWork.Suppliers.GetSupplier(id);

            if (supplier == null)
                return HttpNotFound();

            var viewModel = new SupplierFormViewModel(supplier);

            return View("SupplierForm", viewModel);
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(SupplierFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("SupplierForm", viewModel);

            if (viewModel.Id == 0)
            {
                var newSupplier = new Supplier
                {
                    Name = viewModel.Name,
                    Phone = viewModel.Phone
                };

                _unitOfWork.Suppliers.Add(newSupplier);
            }
            else
            {
                var supplier = _unitOfWork.Suppliers.GetSupplier(viewModel.Id);

                if(supplier == null)
                    return HttpNotFound();


                supplier.Update(viewModel);                
            }

            _unitOfWork.Complete();
            return RedirectToAction("Index", "Suppliers");
        }
    }
}