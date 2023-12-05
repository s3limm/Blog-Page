using Blog_Page.API.Core.Domain;
using Blog_Page.Models;
using Blog_Page.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.Controllers
{
    public class BlogController : Controller
    {
        IRepositoryUI<Blog> _blog;
        public BlogController(IRepositoryUI<Blog> blog)
        {
            _blog = blog;
        }

        public async Task<IActionResult> Index()
        {
            List<Blog> blogs = await _blog.GetAllList();
            return View(blogs);
        }


    }
}
