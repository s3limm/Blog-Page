using Blog_Page.Models;
using Blog_Page.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class CategoryController : Controller
    {
        IRepository<Category> _cat;

        public CategoryController(IRepository<Category> cat)
        {
            _cat = cat;
        }

        public IActionResult List()
        {
            List<Category> cat = _cat.GetAllList();
            return View(cat);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Category cat)
        {
            _cat.Insert(cat);
            return RedirectToAction("List", "Category", new { area = "Admin" });
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Category cat = _cat.GetByID(id);
            return View(cat);
        }

        [HttpPost]
        public IActionResult Edit(Category cat)
        {
            _cat.Update(cat);
            return RedirectToAction("List", "Category", new { area = "Admin" });
        }

        public IActionResult Delete(int id)
        {
            _cat.Delete(id);
            return RedirectToAction("List", "Category", new { area = "Admin" });
        }
    }
}
