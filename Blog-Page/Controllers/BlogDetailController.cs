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
        private readonly IMapper _mapper;
        public BlogDetailController(IRepository<Blog> blog,IMapper mapper)
        {
            _blog = blog;
            _mapper = mapper;
        }

        public IActionResult Index(int id)
        {
            Blog blog = _blog.GetByID(id);
            BlogDto blogDetails = _mapper.Map<BlogDto>(blog);
            return View(blogDetails);
        }
    }
}
