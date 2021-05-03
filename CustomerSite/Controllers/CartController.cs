using Microsoft.AspNetCore.Mvc;

namespace CustomerSite.Controllers
{
    public class CartController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
