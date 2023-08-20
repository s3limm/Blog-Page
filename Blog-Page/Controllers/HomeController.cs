using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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