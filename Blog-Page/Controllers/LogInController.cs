using Blog_Page.DBContext;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.Controllers
{
    public class LogInController : Controller
    {
        private readonly LogInDBContext logInDBContext;

        public LogInController(LogInDBContext _logInDBContext)
        {
            logInDBContext = _logInDBContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(string nameSurname, string PassWord)
        {
            var user = logInDBContext.logIn.FirstOrDefault(u => u.NameSurname == nameSurname && u.Password == PassWord);
            if (user != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Yanlış kullanıcı";
                return View();
            }
        }


    }
}
