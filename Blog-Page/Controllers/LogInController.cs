using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.Controllers
{
    public class LogInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
