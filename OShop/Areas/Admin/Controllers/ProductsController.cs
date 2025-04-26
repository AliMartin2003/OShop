using OShop.Core.Tools;
using Microsoft.AspNetCore.Mvc;
using OShop.Core.Services;
using OShop.Core.Tools;
using OShop.DataLayer.DTOS.AdminViewModels;
using OShop.DataLayer.Entities;

namespace OShop.Controllers
{
    [Area("Admin")]
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

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductViewModel createProductViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createProductViewModel);
            }
            Product product = new Product()
            {
                IsDeleted = false,
                IsExists = createProductViewModel.IsExists,
                IsPublished = createProductViewModel.IsPublished,
                Price = createProductViewModel.Price,
                PublishDate = DateTimeOffset.UtcNow,
                ProductName = createProductViewModel.ProductName,
                SellCount = 0,
                Views = 0,
                ProductDescription = createProductViewModel.ProductDescription,
                ProductGroupId = createProductViewModel.ProductGroupId,
            };
            if (createProductViewModel.Thumbnail != null && createProductViewModel.Thumbnail.Length > 0)
            {
                string imgName = Guid.NewGuid().ToString();
                await PublicTools.SaveOriginalImageAsync(createProductViewModel.Thumbnail, "Prodcuts", imgName);
                await PublicTools.SaveThumbnailImageAsync(createProductViewModel.Thumbnail, "Prodcuts", imgName);
                product.Thumbnail = imgName + Path.GetExtension(createProductViewModel.Thumbnail.FileName);
            }
            if (!_ProductServices.CreateProduct(product))
            {
                TempData["Error"] = "عملیات با موفقیت شکست خورد";
                return Redirect("/Admin/Home/");

            }
            TempData["Error"] = "عملیات با موفقیت مفق خورد";
            return Redirect("/Admin/Home/");
        }


    }
}
