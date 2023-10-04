using AutoMapper;
using Blog_Page.Dto;
using Blog_Page.Models;
using Blog_Page.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.Controllers
{
    public class BlogDetailController : Controller
    {
        IRepository<Blog>_blog;
        IRepository<Category>_category;
        private readonly IMapper _mapper;
        public BlogDetailController(IRepository<Blog> blog,IMapper mapper, IRepository<Category> category)
        {
            _blog = blog;
            _mapper = mapper;
            _category = category;
        }

        public IActionResult Index(int id)
        {
            Blog blog = _blog.GetByID(id);
            var cat = _category.GetByID(blog.CategoryID);
            blog.Category = cat;
            CategoryDto catMapped = _mapper.Map<CategoryDto>(blog.Category);
            BlogDto blogDetails = _mapper.Map<BlogDto>(blog);
            return View(blogDetails);
        }
    }
}
