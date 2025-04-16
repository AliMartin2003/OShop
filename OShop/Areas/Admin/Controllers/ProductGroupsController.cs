using Microsoft.AspNetCore.Mvc;
using OShop.Core.Interfaces;
using OShop.Core.Tools;
using OShop.DataLayer.DTOS.AdminViewModels;
using OShop.DataLayer.Entities;

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
        public IActionResult CreateBlogGroup(CreateProductGroupViewModel createProduct)
        {
            if (!ModelState.IsValid)
            {
                return View(createProduct);
            }
            ProductGroup productGroup = new ProductGroup()
            {
                ProductGroupName = createProduct.ProducGrouptName,
            };
            if (productGroup.ProductGroupImage!=null && productGroup.ProductGroupImage.Length>0)
            {
                if (!PublicServicesTools.IsImage(createProduct.ProductGroupImage))
                {
                    throw new Exception("این فایل تصویر نیست");
                }
                PublicServicesTools.SaveImage(createProduct.ProductGroupImage, "ProductGroups","Qualitied");
                IFormFile compressed = PublicServicesTools.CompressImage(createProduct.ProductGroupImage);
                PublicServicesTools.SaveImage(createProduct.ProductGroupImage, "ProductGroups", "Minified");

            }
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
