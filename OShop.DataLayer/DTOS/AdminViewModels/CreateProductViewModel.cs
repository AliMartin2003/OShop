using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OShop.DataLayer.DTOS.AdminViewModels
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "لطفاً نام محصول را وارد کنید.")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "نام محصول باید بین {2} تا {1} کاراکتر باشد.")]
        [Display(Name = "نام محصول")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "لطفاً توضیحات محصول را وارد کنید.")]
        [StringLength(500,
            ErrorMessage = "توضیحات محصول نمی‌تواند بیش از {1} کاراکتر باشد.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "توضیحات محصول")]
        public string ProductDescription { get; set; }

        [Display(Name = "موجود است؟")]
        public bool IsExists { get; set; } = true;

        [Display(Name = "منتشر شده؟")]
        public bool IsPublished { get; set; } = true;

        [Required(ErrorMessage = "لطفاً یک تصویر شاخص بارگذاری کنید.")]
        [DataType(DataType.Upload)]
        [Display(Name = "تصویر شاخص")]
        public IFormFile Thumbnail { get; set; }

        [Required(ErrorMessage = "لطفاً قیمت را تعیین کنید.")]
        [Range(0.0, 100000.0,
            ErrorMessage = "قیمت باید بین {1} تا {2} باشد.")]
        [DataType(DataType.Currency)]
        [Display(Name = "قیمت")]
        public double Price { get; set; } = 0;

        [Required(ErrorMessage = "لطفاً گروه محصول را تعیین کنید.")]
        [Display(Name = "گروه محصول")]
        public int ProductGroupId { get; set; }
    }
}
