using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
