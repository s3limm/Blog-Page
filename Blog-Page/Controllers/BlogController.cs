using Blog_Page.DBContext;
using Blog_Page.Models;
using Blog_Page.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.Controllers
{
    public class BlogController : Controller
    {
        IRepository<Blog> _blog;
        public BlogController(IRepository<Blog> blog)
        {
            _blog = blog;
        }

        public IActionResult Index()
        {
            List<Blog> blogs = _blog.GetAllList();
            return View(blogs);
        }


    }
}
