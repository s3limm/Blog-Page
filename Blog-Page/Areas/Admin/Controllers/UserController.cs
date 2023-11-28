using Blog_Page.DBContext;
using Blog_Page.Models;
using Blog_Page.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        IRepository<AppUser> _user;
        AddDbContext _db;

        public UserController(IRepository<AppUser> user, AddDbContext db)
        {
            _user = user;
            _db = db;
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
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            _user.Insert(user);
            return RedirectToAction("List", "User", new { area = "Admin" });
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            AppUser user = _user.GetByID(id);
            return View(user);
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


        public ActionResult Jquery()
        {
            List<AppUser> users = _db.Users.ToList();
            return View(users);
        }

        public JsonResult GetJson()
        {
            List<AppUser> users = _db.Users.ToList();
            return Json(users);
        }

        //public ActionResult Jquery()
        //{
        //    List<AppUser> users = _db.Users.ToList();
        //    return View(users);
        //}

        //public JsonResult GetJson()
        //{
        //    List<AppUser> users = _db.Users.ToList();
        //    return Json(users);
        //}

        //public IActionResult GetJsonWithAjax()
        //{
        //    return View();
        //}

        //public IActionResult GetJsonWithAjax2()
        //{
        //    List<AppUser> users = _db.Users.ToList();
        //    var usersJson = JsonConvert.SerializeObject(users);
        //    return Json(usersJson);
        //}

    }
}
