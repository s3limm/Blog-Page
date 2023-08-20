using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.Areas.Blog.Controllers
{
    [Area("Blog")]
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
