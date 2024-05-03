using System;
using System.Data;
using AutoMapper;
using Blog_Page.Domain.BlogPage.Dtos.Blog;
using Blog_Page.Domain.Entities;
using Blog_Page.Domain.Enums;
using Blog_Page.Model.Blog.Request;
using Blog_Page.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Blog_Page.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IRepository<Blog> _service;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;


        public BlogController(IRepository<Blog> service, IMapper mapper, IWebHostEnvironment environment)
        {
            _service = service;
            _mapper = mapper;
            _environment = environment;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _service.GetListAsync();
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _service.GetAsync(id);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CreateBlogRequest request)
        {
            foreach (var item in request.files)
            {

                if (item.FileName == null || item.FileName.Length == 0)
                {
                    return Content("File not selected");
                }
                var path = Path.Combine(_environment.WebRootPath, "Images/", item.FileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                    stream.Close();
                }


                //Insert In User Profile table
                await _service.CreateAsync(new Blog
                {
                    Title = request.Title,
                    Description = request.Description,
                    Content = request.Content,
                    CategoryID = request.CategoryID,
                    ImageName = item.FileName,
                    ImagePath = path
                });
            }
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var data = await _service.GetAsync(id);

            if(data != null)
            {
                await _service.DeleteAsync(data);
            }
            return NoContent();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(UpdateBlogRequest request)
        {
            var data = await _service.GetAsync(request.ID);
            if(data!=null)
            {
                data.Title = request.Title;
                data.Description = request.Description;
                data.Content = request.Content;
                data.CategoryID = request.CategoryID;
            }
            await _service.UpdateAsync(data);
            return Ok();
        }
    }
}
