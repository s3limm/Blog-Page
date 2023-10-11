using AutoMapper;
using Azure.Core;
using Blog_Page.DBContext;
using Blog_Page.Dto;
using Blog_Page.Models;
using Blog_Page.Repositories.Interfaces;
using Blog_Page.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

namespace Blog_Page.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IMapper _mapper;
        IRepository<Blog> _blog;
        AddDbContext _db;
        private readonly IImageService _imageService;
        public BlogController(IRepository<Blog> blog, AddDbContext db, IMapper mapper, IImageService imageService)
        {
            _db = db;
            _blog = blog;
            _mapper = mapper;
            _imageService = imageService;
        }

        public string FilePath;

        public IActionResult List()
        {
            List<Blog> blog = _blog.GetAllList();
            return View(blog);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            var result = new BlogDto();
            result.Categories = _db.Categories.Where(x => x.Status != Enums.Status.Deleted).Select(x => new CategoryDto { CategoryName = x.CategoryName, ID = x.ID }).ToList();
            return View(result);
        }

        [HttpPost]
        public IActionResult Insert(BlogDto blog, IFormFile file)
        {
            UploadImage(file);
            Blog blogEntity = _mapper.Map<Blog>(blog);
            _blog.Insert(blogEntity);
            return RedirectToAction("List", "Blog", new { area = "Admin" });
        }

        public async void UploadImage(IFormFile file)
        {
            if (file != null)
            {
                FilePath = await _imageService.UploadFileAsync(file);
            }
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Blog blog = _blog.GetByID(id);
            BlogDto blogDto = _mapper.Map<BlogDto>(blog);
            blogDto.Categories = _db.Categories.Where(x => x.Status != Enums.Status.Deleted).Select(x => new CategoryDto { CategoryName = x.CategoryName, ID = x.ID }).ToList();
            return View(blogDto);
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
