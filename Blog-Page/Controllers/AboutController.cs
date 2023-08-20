using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
