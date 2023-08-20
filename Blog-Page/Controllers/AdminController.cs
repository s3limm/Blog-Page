using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
