﻿using System;
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
        public async Task<IActionResult> CreateAsync([FromForm] CreateBlogRequest request)
        {
            string path = "C:\\Users\\YAVUZ\\Desktop\\GitHub\\Blog-Page\\Blog-Page\\wwwroot\\Uploads\\";

            if (request.FileData != null)
            {
                // Eğer upload klasörü yoksa oluştur
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Dosya işlemleri
                foreach (var file in request.FileData)
                {
                    if (file.Length > 0)
                    {
                        // Dosyayı wwwroot/upload klasörüne kaydet
                        var filePath = Path.Combine(path, file.FileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                }
            }

            string fileNames = string.Join(",", request.FileData.Select(f => f.FileName));

            await _service.CreateAsync(new Blog
            {
                Title = request.Title,
                Description = request.Description,
                Content = request.Content,
                CategoryID = request.CategoryID,
                FileNames = fileNames
            });
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var data = await _service.GetAsync(id);

            if (data != null)
            {
                await _service.DeleteAsync(data);
            }
            return NoContent();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromForm]UpdateBlogRequest request)
        {
            var data = await _service.GetAsync(request.ID);
            string fileNames = string.Join(",", request.FileData.Select(f => f.FileName));

            if (data != null)
            {
                data.Title = request.Title;
                data.Description = request.Description;
                data.Content = request.Content;
                data.CategoryID = request.CategoryID;
                data.FileNames = fileNames;
            }
            await _service.UpdateAsync(data);
            return Ok();
        }
    }
}
