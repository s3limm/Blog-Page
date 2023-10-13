
using Blog_Page.DBContext;
using Blog_Page.Enums;
using Blog_Page.Models;
using Blog_Page.Repositories.Interfaces;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Blog_Page.Areas.Login.Controllers
{
    [Area("Login")]
    public class LogInController : Controller
    {
        private readonly IRepository<AppUser> _user;
        public LogInController(IRepository<AppUser> user)
        {
            _user = user;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AppUser user)
        {
            if (_user.Any(x => x.userName == user.userName && x.Status != Enums.Status.Deleted))
            {
                AppUser selectedUser = _user.Default(x => x.userName == user.userName && x.Status != Enums.Status.Deleted);
                bool isValid = BCrypt.Net.BCrypt.Verify(user.Password, selectedUser.Password);
                if (isValid)
                {
                    if (selectedUser.Role == Role.Admin)
                    {
                        return RedirectToAction("Home", "Admin", new { area = "Admin" });
                    }
                }
            }
            return View();
        }

    }
}
