using AutoMapper;
using MyStorage.Core;
using MyStorage.Core.Dtos.Category;
using MyStorage.Core.Models;
using System.Linq;
using System.Web.Http;

namespace MyStorage.Controllers.Api
{
    [Authorize]
    public class CategoriesController : ApiController
    {        
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }        

        //GET: /Api/Categories
        [AllowAnonymous]
        public IHttpActionResult GetCategories()
        {
            var categoryDtos = _unitOfWork.Categories
                .GetCategories()
                .Select(Mapper.Map<Category, CategoryDto>);                

            return Ok(categoryDtos);
        }
    }
}
