using AutoMapper;
using Blog_Page.DBContext;
using Blog_Page.Dto;
using Blog_Page.Models;
using Blog_Page.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IMapper _mapper;
        IRepository<Blog> _blog;
        AddDbContext _db;

        public BlogController(IRepository<Blog> blog, AddDbContext db,IMapper mapper)
        {
            _db = db;
            _blog = blog;
            _mapper = mapper;
        }

        public IActionResult List()
        {
            List<Blog> blog = _blog.GetAllList();
            return View(blog);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            var result = new BlogDto();
            result.Categories  = _db.Categories.Where(x => x.Status != Enums.Status.Deleted).Select(x => new CategoryDto { CategoryName = x.CategoryName , ID = x.ID}).ToList();
            return View(result);
        }

        [HttpPost]
        public IActionResult Insert(BlogDto blog)
        {
            Blog blogEntity = _mapper.Map<Blog>(blog);
            _blog.Insert(blogEntity);
            return RedirectToAction("List", "Blog", new { area = "Admin" });
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
           var blog = typeof(BlogDto)_blog.GetByID(id);
           
            
            return View(blog);
        }

        [HttpPost]
        public IActionResult Edit(BlogDto blogDto)
        {
            Blog blogEntity = _mapper.Map<Blog>(blogDto);
            _blog.Update(blogEntity);
            return RedirectToAction("List", "Blog", new { area = "Admin" });
        }

        public IActionResult Delete(int id)
        {
            _blog.Delete(id);
            return RedirectToAction("List", "Blog", new { area = "Admin" });
        }
    }
}
