using Blog_Page.DBContext;
using Blog_Page.Models;
using Blog_Page.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        IRepository<AppUser> _user;

        public UserController(IRepository<AppUser> user)
        {
            _user = user;
        }

        public IActionResult List()
        {
            List<AppUser> users = _user.GetAllList();
            return View(users);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(AppUser user)
        {
            _user.Insert(user);
            return RedirectToAction("List", "User", new {area="Admin"});
        }


        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(AppUser user)
        {
            _user.Update(user);
            return RedirectToAction("List", "User", new { area = "Admin" });
        }

        public IActionResult Delete(int id)
        {
            _user.Delete(id);
            return RedirectToAction("List", "User", new { area = "Admin" });
        }
    }
}
