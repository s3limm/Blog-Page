using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.Controllers
{
    public class BlogAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
