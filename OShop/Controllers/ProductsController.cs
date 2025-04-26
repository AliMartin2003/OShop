using Microsoft.AspNetCore.Mvc;
using OShop.Core.Services;
using OShop.DataLayer.DTOS.Main;

namespace OShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProduct _ProductServices;
        public ProductsController(IProduct ProductServices)
        {
            _ProductServices = ProductServices;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult ShowProduct(string id)
        {
            var product = _ProductServices.GetProductByName(id);
            if (product==null)
            {
                return NotFound("لطفا url را انگولک نکنید");
            }
            ShowProductViewModel showProduct = new ShowProductViewModel()
            {
                IsExists = product.IsExists,
                Price = product.Price,
                ProductDescription = product.ProductDescription,
                ProductGroupId = product.ProductGroupId,
                ProductName = product.ProductName,
                SellCount = product.SellCount,
                Seller = product.Seller.UserDisplayName,
                Thumbnail = product.Thumbnail,
            };
            return View(showProduct);
        }
    }
}
