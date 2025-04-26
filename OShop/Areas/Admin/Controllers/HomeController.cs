using Microsoft.AspNetCore.Mvc;
using OShop.Core.Interfaces;
using OShop.Core.Services;

namespace OShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IUser _UserServices;
        private readonly IProduct _ProductServices;
        private readonly IProductGroup _ProductGroupServices;
        public HomeController(IUser UserServices, IProduct ProductServices,IProductGroup ProductGroupServices)
        {
            _UserServices = UserServices;
            _ProductGroupServices = ProductGroupServices;
            _ProductServices = ProductServices;
        }

        public IActionResult Index()
        {
            ViewBag.UserCounts = _UserServices.GetUserCounts();
            ViewBag.ProductsCount = _ProductServices.GetProductsCount();
            return View();
        }
    }
}
