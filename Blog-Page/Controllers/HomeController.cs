﻿using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
