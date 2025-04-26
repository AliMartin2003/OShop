using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OShop.Core.Services;
using OShop.Models;

namespace OShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProduct _ProductServices;
        public HomeController(ILogger<HomeController> logger, IProduct ProductServices)
        {
            _logger = logger;
            _ProductServices = ProductServices;
        }

        public IActionResult Index()
        {
            ViewBag.Products = _ProductServices.GetProducts().ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}