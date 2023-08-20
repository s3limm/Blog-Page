using Blog_Page.DBContext;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.Areas.Login.Controllers
{
    [Area("Login")]
    public class LogInController : Controller
    {
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }       

    }
}
