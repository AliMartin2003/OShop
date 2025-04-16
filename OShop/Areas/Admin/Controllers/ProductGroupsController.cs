using Microsoft.AspNetCore.Mvc;
using OShop.Core.Interfaces;

namespace OShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductGroupsController : Controller
    {
        private readonly IProductGroup _productGroupServices;
        public ProductGroupsController(IProductGroup productGroup)
        {
            _productGroupServices = productGroup;
        }

        public IActionResult Index()
        {
            var ProductGroups = _productGroupServices.GetProductGroups().ToList();
            return View(ProductGroups);
        }

        [HttpGet]
        public IActionResult CreateBlogGroup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBlogGroup()
        {
            return View();
        }

        public IActionResult UpdateBlogGroup()
        {
            return View();
        }
        public IActionResult DeleteBlogGroup(int id)
        {
            return View();
        }
    }
}
