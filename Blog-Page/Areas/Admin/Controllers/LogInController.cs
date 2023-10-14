using Blog_Page.Enums;
using Blog_Page.Models;
using Blog_Page.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Blog_Page.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LogInController : Controller
    {
        private readonly IRepository<AppUser> _user;
        public LogInController(IRepository<AppUser> user)
        {
            _user = user;
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> LogIn(AppUser user)
        {
            if (_user.Any(x => x.userName == user.userName && x.Status != Enums.Status.Deleted))
            {
                AppUser selectedUser = _user.Default(x => x.userName == user.userName && x.Status != Enums.Status.Deleted);
                bool isValid = BCrypt.Net.BCrypt.Verify(user.Password, selectedUser.Password);
                if (isValid)
                {
                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim (ClaimTypes.Name,selectedUser.userName),
                        new Claim (ClaimTypes.NameIdentifier,selectedUser.ID.ToString()),
                        new Claim (ClaimTypes.Role,selectedUser.Role.ToString())
                    };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);
                    if (selectedUser.Role == Role.Admin)
                    {
                        return RedirectToAction("Home", "Admin", new { area = "Admin" });
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("LogIn", "Login", new { area = "Admin" });
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
