using AutoMapper;
using Blog_Page.Domain.BlogPage.Dtos.Category;
using Blog_Page.Domain.Entities;
using Blog_Page.Model.Category.Request;
using Blog_Page.Service.Interfaces;
using Blog_Page.Service.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _service;
        private readonly IMapper _mapper;

        public CategoryController(IMapper mapper, IRepository<Category> service)
        {

            _mapper = mapper;
            _service = service;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetListAsync()
        {
            var list = await _service.GetListAsync();
            return Ok(list);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var data = await _service.GetAsync(id);
            return Ok(data);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CreateCategoryRequest request)
        {
            await _service.CreateAsync(new Category
            {
                CategoryName = request.CategoryName
            });
            return Created("", request.CategoryName);
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
        public async Task<IActionResult> UpdateAsync(UpdateCategoryRequest request)
        {
            var entity = await _service.GetAsync(request.Id);
            if(entity!= null)
            {
                entity.CategoryName = request.CategoryName;
            }
            await _service.UpdateAsync(entity);
            return Ok(request.CategoryName);
        }
    }
}
