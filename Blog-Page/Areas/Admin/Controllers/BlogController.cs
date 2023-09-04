using Blog_Page.DBContext;
using Blog_Page.Models;
using Blog_Page.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        IRepository<Blog> _blog;
        AddDbContext _db;

        public BlogController(IRepository<Blog> blog, AddDbContext db)
        {
            _db = db;
            _blog = blog;
        }

        public IActionResult List()
        {
            List<Blog> blog = _blog.GetAllList();
            return View(blog);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Blog blog)
        {
            _blog.Insert(blog);
            return RedirectToAction("List", "Blog", new { area = "Admin" });
        }


        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
            _blog.Update(blog);
            return RedirectToAction("List", "Blog", new { area = "Admin" });
        }

        public IActionResult Delete(int id)
        {
            _blog.Delete(id);
            return RedirectToAction("List", "Category", new { area = "Admin" });
        }
    }
}
