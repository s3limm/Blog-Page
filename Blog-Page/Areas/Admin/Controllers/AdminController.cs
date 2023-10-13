using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.Areas.Admin.Controllers
{
    //[Authorize]
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
