using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog_Page.Areas.Blog.Controllers
{
    [Area("Blog")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}