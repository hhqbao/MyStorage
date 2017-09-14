using System.Web.Mvc;

namespace MyStorage.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }       
    }
}