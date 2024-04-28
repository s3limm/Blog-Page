using Blog_Page.Domain.Entities;
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
            List<Blog> blogs = await _blog.GetListAsync();
            return View(blogs);
        }


    }
}
