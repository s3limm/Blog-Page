using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.Controllers
{
    public class BlogDetailController : Controller
    {
        public IActionResult BlogDetail()
        {
            return View();
        }
    }
}
