using AutoMapper;
using MyStorage.Core;
using MyStorage.Core.Dtos.Supplier;
using MyStorage.Core.Models;
using System.Linq;
using System.Web.Http;

namespace MyStorage.Controllers.Api
{
    [Authorize]
    public class SuppliersController : ApiController
    {        
        private readonly IUnitOfWork _unitOfWork;

        public SuppliersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }        

        //GET: /Api/Suppliers
        [AllowAnonymous]
        public IHttpActionResult GetSuppliers()
        {
            var supplierDtos = _unitOfWork.Suppliers.GetSuppliersWithProducts();

            return Ok(supplierDtos.Select(Mapper.Map<Supplier, SupplierDto>));
        }

        
    }
}
