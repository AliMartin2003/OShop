﻿using Microsoft.AspNetCore.Mvc;

namespace OShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductGroupsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
