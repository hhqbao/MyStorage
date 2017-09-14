using MyStorage.Core;
using MyStorage.Core.Models;
using MyStorage.Core.ViewModels;
using System.Data.Entity.Core;
using System.Web.Mvc;

namespace MyStorage.Controllers
{
    [Authorize]
    public class CategoryTypesController : Controller
    {        
        private readonly IUnitOfWork _unitOfWork;

        public CategoryTypesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int categoryId)
        {
            var viewModel = new CategoryTypeViewModel
            {
                CategoryId = categoryId
            };

            return View("CategoryTypeForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var categoryType = _unitOfWork.CategoryTypes.GetCategoryType(id);

            if (categoryType == null)
                return HttpNotFound();

            var viewModel = new CategoryTypeViewModel(categoryType);

            return View("CategoryTypeForm", viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CategoryTypeViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("CategoryTypeForm", viewModel);

            if (IsAddingNewCategoryType(viewModel))
            {
                AddNewCategoryType(viewModel);
            }
            else
            {
                UpdateCategoryType(viewModel);
            }

            _unitOfWork.Complete();
            return RedirectToAction("ListCategoryTypes", "Categories", new { id = viewModel.CategoryId });
        }

        private void UpdateCategoryType(CategoryTypeViewModel viewModel)
        {
            var categoryType = _unitOfWork.CategoryTypes.GetCategoryType(viewModel.Id);

            if (categoryType == null)
                throw new ObjectNotFoundException();

            categoryType.Name = viewModel.Name;
            _unitOfWork.Complete();
        }

        private void AddNewCategoryType(CategoryTypeViewModel viewModel)
        {
            var categoryType = new CategoryType
            {
                Name = viewModel.Name,
                CategoryId = viewModel.CategoryId
            };

            _unitOfWork.CategoryTypes.Add(categoryType);
            _unitOfWork.Complete();
        }

        private bool IsAddingNewCategoryType(CategoryTypeViewModel viewModel)
        {
            return viewModel.Id == 0;
        }
    }
}