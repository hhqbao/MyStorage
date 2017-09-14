using MyStorage.Core;
using MyStorage.Core.Models;
using MyStorage.Core.ViewModels;
using System.Data.Entity.Core;
using System.Web.Mvc;

namespace MyStorage.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {        
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }        

        public ActionResult ListCategoryTypes(int id)
        {
            var category = _unitOfWork.Categories.GetCategoryWithTypes(id);

            if (category == null)
                return HttpNotFound();

            return View(category);
        }


        public ActionResult Index()
        {
            var categories = _unitOfWork.Categories.GetCategories();

            return View(categories);
        }


        public ActionResult Create()
        {
            return View("CategoryForm", new CategoryFormViewModel());
        }

        public ActionResult Edit(int id)
        {
            var category = _unitOfWork.Categories.GetCategoryWithTypes(id);

            if (category == null)
                return HttpNotFound();

            return View("CategoryForm", new CategoryFormViewModel(category));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CategoryFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("CategoryForm", viewModel);

            if (IsAddingNewCategory(viewModel))
            {
                AddNewCategory(viewModel);
            }
            else
            {
                UpdateCategory(viewModel);
            }

            return RedirectToAction("Index", "Categories");
        }

        private void UpdateCategory(CategoryFormViewModel viewModel)
        {
            var category = _unitOfWork.Categories.GetCategoryWithTypes(viewModel.Id);

            if (category == null)
                throw new ObjectNotFoundException();

            category.Name = viewModel.Name;
            _unitOfWork.Complete();
        }

        private void AddNewCategory(CategoryFormViewModel viewModel)
        {
            var newCategory = new Category
            {
                Name = viewModel.Name
            };

            _unitOfWork.Categories.Add(newCategory);
            _unitOfWork.Complete();
        }

        private bool IsAddingNewCategory(CategoryFormViewModel viewModel)
        {
            return viewModel.Id == 0;
        }
    }
}