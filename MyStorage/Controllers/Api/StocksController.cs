using AutoMapper;
using MyStorage.Core;
using MyStorage.Core.Dtos.Stock;
using MyStorage.Core.Models;
using System.Linq;
using System.Web.Http;

namespace MyStorage.Controllers.Api
{
    [Authorize]
    public class StocksController : ApiController
    {        
        private readonly IUnitOfWork _unitOfWork;        

        public StocksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }       

        //GET: /Api/Stocks
        [AllowAnonymous]
        public IHttpActionResult GetStocks()
        {
            var stockDtos = _unitOfWork.Stocks.GetStocksWithProduct();                

            return Ok(stockDtos.Select(Mapper.Map<Stock, StockDto>));
        }

        

        [HttpPost]
        public IHttpActionResult NewStock(StockDto viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var newStock = new Stock(viewModel);

            _unitOfWork.Stocks.Add(newStock);        
            _unitOfWork.Complete();

            return Ok(Mapper.Map<Stock, StockDto>(newStock));
        }

        [HttpPut]
        public IHttpActionResult UpdateStock(int id, StockDto viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var stockInDb = _unitOfWork.Stocks.GetStock(id);

            if (stockInDb == null)
                return NotFound();

            Mapper.Map(viewModel, stockInDb);

            var change = StockChange.UpdatedChange(stockInDb);

            _unitOfWork.StockChanges.Add(change);
            _unitOfWork.Complete();

            return Ok();
        }

        

        [HttpPut]
        public IHttpActionResult UpdateQuantity(int stockId, int quantity, bool sendMessage)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Stock stockInDb = null;

            stockInDb = sendMessage ? _unitOfWork.Stocks.GetStockWithProductAndSupplier(stockId) 
                : _unitOfWork.Stocks.GetStock(stockId);


            if (stockInDb == null)
                return NotFound();

            stockInDb.UpdateQuantity(quantity, sendMessage);

            var change = StockChange.UpdatedChange(stockInDb);

            _unitOfWork.StockChanges.Add(change);
            _unitOfWork.Complete();

            return Ok();
        }

        

        [HttpDelete]
        public IHttpActionResult DeleteStock(int id)
        {
            var stockInDb = _unitOfWork.Stocks.GetStock(id);

            if (stockInDb == null)
                return NotFound();

            _unitOfWork.Stocks.Remove(stockInDb);
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
