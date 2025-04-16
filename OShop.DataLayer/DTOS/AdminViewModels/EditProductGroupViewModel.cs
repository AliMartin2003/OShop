using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OShop.DataLayer.DTOS.AdminViewModels
{
	public class EditProductGroupViewModel
	{
		[Required(ErrorMessage = "مقدار شناسه گروه الزامی است")]
		public int Id { get; set; }
		[Required(ErrorMessage = "مقدار نام گروه الزامی است")]
		[MaxLength(20, ErrorMessage = "حداکثر تعداد حروف باید 20 کاراکتر باشد")]
		public string ProductGroupName { get; set; }
		public IFormFile? ProductGroupImage { get; set; }
		public string ProductGroupImageName { get; set; }
	}
}
