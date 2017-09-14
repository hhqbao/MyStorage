using MyStorage.Core;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebGrease.Css.Extensions;

namespace MyStorage.Controllers
{
    public class StocksController : Controller
    {        
        private readonly JavaScriptSerializer _serializer;
        private readonly IUnitOfWork _unitOfWork;

        public StocksController(IUnitOfWork unitOfWork)
        {            
            _serializer = new JavaScriptSerializer();
            _unitOfWork = unitOfWork;
        }

        public void UpdateEvent()
        {
            Response.ContentType = "text/event-stream";

            DateTime startDate = DateTime.Now;
            while (startDate.AddMinutes(1) > DateTime.Now)
            {
                var changes = _unitOfWork.StockChanges.GetUnreadChanges();

                var result = _serializer.Serialize(changes);

                Response.ContentType = "text/event-stream";

                Response.Write(String.Format("data:{0}\n\n", result));
                Response.Flush();

                System.Threading.Thread.Sleep(2000);

                if (changes.Any())
                {
                    changes.ForEach(c => c.Read());
                    _unitOfWork.Complete();
                }
            }

            Response.Close();
        }


    }
}