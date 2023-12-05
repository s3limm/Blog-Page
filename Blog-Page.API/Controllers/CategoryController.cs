using Blog_Page.API.Core.Application.Features.CQRS.Commands.Blog.Delete;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.Category.Create;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.Category.Delete;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.Category.Update;
using Blog_Page.API.Core.Application.Features.CQRS.Queries.Category.Get;
using Blog_Page.API.Core.Application.Features.CQRS.Queries.Category.List;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _mediator.Send(new GetAllCategoriesQueryRequest());
            return Ok(result);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQueryRequest(id));
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request.CategoryName);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _mediator.Send(new DeleteCategoryCommandRequest(id));
            return NoContent();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(request.CategoryName);
        }
    }
}
