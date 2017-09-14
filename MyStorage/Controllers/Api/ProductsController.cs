using AutoMapper;
using MyStorage.Core;
using MyStorage.Core.Dtos.Product;
using MyStorage.Core.Models;
using System.Linq;
using System.Web.Http;

namespace MyStorage.Controllers.Api
{
    [Authorize]
    public class ProductsController : ApiController
    {        
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }        

        //GET: /Api/Products
        [AllowAnonymous]
        public IHttpActionResult GetProducts()
        {
            var products = _unitOfWork.Products.GetProductsWithCategoryAndType();

            return Ok(products.Select(Mapper.Map<Product, ProductDto>));
        }

       

        //GET: /Api/Products?name=abcd
        [AllowAnonymous]
        public IHttpActionResult GetProducts(string name)
        {
            var products = _unitOfWork.Products.GetProductsByName(name);

            return Ok(products.Select(Mapper.Map<Product, ProductDto>));
        }
       
        [HttpPost]
        public IHttpActionResult CreateProduct(ProductDto viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = Mapper.Map<ProductDto, Product>(viewModel);

            _unitOfWork.Products.Add(product);
            _unitOfWork.Complete();

            return Ok(product);
        }

        [HttpPut]
        public IHttpActionResult UpdateProduct(ProductDto viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var productInDb = _unitOfWork.Products.GetProduct(viewModel.Id);

            if (productInDb == null)
                return NotFound();

            productInDb.Update(viewModel);

            _unitOfWork.Complete();
            return Ok(Mapper.Map<Product, ProductDto>(productInDb));
        }       

        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            var productInDb = _unitOfWork.Products.GetProduct(id);

            if (productInDb == null)
                return NotFound();

            _unitOfWork.Products.Remove(productInDb);
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
