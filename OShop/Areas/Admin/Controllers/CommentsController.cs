using Microsoft.AspNetCore.Mvc;

namespace OShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
