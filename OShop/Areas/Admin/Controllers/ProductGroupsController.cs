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
        public IActionResult CreateProductGroup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductGroup(CreateProductGroupViewModel createProduct)
        {
            if (!ModelState.IsValid)
            {
                return View(createProduct);
            }
            ProductGroup productGroup = new ProductGroup()
            {
                ProductGroupName = createProduct.ProductGroupName,
            };
            if (createProduct.ProductGroupImage != null && createProduct.ProductGroupImage.Length > 0)
            {


                string ImageName = Guid.NewGuid().ToString();
                await PublicTools.SaveOriginalImageAsync(createProduct.ProductGroupImage, "ProductGroups", ImageName);
                await PublicTools.SaveThumbnailImageAsync(createProduct.ProductGroupImage, "Thumb", ImageName);
                productGroup.ProductGroupImage = ImageName + Path.GetExtension(createProduct.ProductGroupImage.FileName);
            }
            if (!_productGroupServices.CreateProductGroup(productGroup))
            {
                TempData["Error"] = "عملیات با موفقیت شکست خورد";
                return Redirect("/admin/Home/index");
            }
            TempData["Success"] = "عملیات با موفقیت انجام شد";
            return Redirect("/admin/Home/index");
        }

        [HttpGet]
        public IActionResult UpdateProductGroup(int id)
        {
            ProductGroup productGroup = _productGroupServices.GetProductGroup(id);
            if (productGroup == null)
            {
                TempData["Error"] = "گروه یافت نشد";
                return Redirect("/Admin/ProductGroups/index");
            }
            EditProductGroupViewModel edit = new EditProductGroupViewModel
            {
                Id = productGroup.ProductGroupId,
                ProductGroupImageName = productGroup.ProductGroupImage,
                ProductGroupName = productGroup.ProductGroupName,
            };
            return View(edit);
        }

        [HttpPost]
        public IActionResult UpdateProductGroup()
        {
            return View();
        }
        public IActionResult DeleteBlogGroup(int id)
        {
            return View();
        }
    }
}
