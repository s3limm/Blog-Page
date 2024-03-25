using AutoMapper;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.Blog.Delete;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.Category.Create;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.Category.Delete;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.Category.Update;
using Blog_Page.API.Core.Application.Features.CQRS.Queries.Category.Get;
using Blog_Page.API.Core.Application.Features.CQRS.Queries.Category.List;
using Blog_Page.Domain.BlogPage.Dtos.Category;
using Blog_Page.Model.Category.Request;
using Blog_Page.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public CategoryController(IMapper mapper, ICategoryService service)
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
            var data = await _service.FindAsync(id);
            return Ok(data);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CreateCategoryRequest request)
        {
            await _service.CreateAsync(new CreateCategoryDto
            {
                CategoryName = request.CategoryName
            });
            return Created("", request.CategoryName);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var data = await _service.FindAsync(id);
            if(data != null)
            {
                await _service.DeleteAsync(data);
            }
            return NoContent();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(UpdateCategoryCommandRequest request)
        {
            var data = await _service.FindAsync(request.Id);
            if(data!=null)
            {
                data.CategoryName = request.CategoryName;
            };
            var mappedData = _mapper.Map<UpdateCategoryDto>(data);
            await _service.UpdateAsync(mappedData);
            return Ok(request.CategoryName);
        }
    }
}
