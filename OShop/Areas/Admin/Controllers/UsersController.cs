﻿using Microsoft.AspNetCore.Mvc;

namespace OShop.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
