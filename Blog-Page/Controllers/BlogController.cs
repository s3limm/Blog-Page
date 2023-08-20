using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
