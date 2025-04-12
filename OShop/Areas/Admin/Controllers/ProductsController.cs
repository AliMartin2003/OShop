using Microsoft.AspNetCore.Mvc;

namespace OShop.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
