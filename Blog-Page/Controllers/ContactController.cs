using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
