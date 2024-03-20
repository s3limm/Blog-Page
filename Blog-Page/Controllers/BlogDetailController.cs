using AutoMapper;
using Blog_Page.API.Core.Domain;
using Blog_Page.Models;
using Blog_Page.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.Controllers
{
    public class BlogDetailController : Controller
    {
        private readonly IRepositoryUI<Blog>_blog;
        private readonly IRepositoryUI<Category>_category;
        private readonly IMapper _mapper;
        public BlogDetailController(IRepositoryUI<Blog> blog,IMapper mapper, IRepositoryUI<Category> category)
        {
            _blog = blog;
            _mapper = mapper;
            _category = category;
        }

        public async Task<IActionResult> Index(int id)
        {
            Blog blog = await _blog.GetByIDAsync(id);
            var cat = await _category.GetByIDAsync(blog.CategoryID);
            blog.Category = cat;
            CategoryListModel catMapped = _mapper.Map<CategoryListModel>(blog.Category);
            BlogListModel blogDetails = _mapper.Map<BlogListModel>(blog);
            return View(blogDetails);
        }
    }
}
