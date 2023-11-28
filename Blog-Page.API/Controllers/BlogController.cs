using Blog_Page.API.Core.Application.Features.CQRS.Commands.Blog.Create;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.Blog.Delete;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.Blog.Update;
using Blog_Page.API.Core.Application.Features.CQRS.Queries.Blog.BlogList;
using Blog_Page.API.Core.Application.Features.CQRS.Queries.Blog.GetBlog;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetAllBlogs()
        {
            var result = await _mediator.Send(new GetBlogListQueryRequest());
            return Ok(result);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var result = await _mediator.Send(new GetBlogByIdQueryRequest(id));
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateBlog(CreateBlogCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteBlog(DeleteBlogCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
