using Blog_Page.API.Core.Application.Features.CQRS.Commands.Blog.Create;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.Blog.Delete;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.Blog.Update;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.User.Create;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.User.Delete;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.User.Update;
using Blog_Page.API.Core.Application.Features.CQRS.Queries.Blog.BlogList;
using Blog_Page.API.Core.Application.Features.CQRS.Queries.Blog.GetBlog;
using Blog_Page.API.Core.Application.Features.CQRS.Queries.User.Get;
using Blog_Page.API.Core.Application.Features.CQRS.Queries.User.List;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _mediator.Send(new GetUserListQueryRequest());
            return Ok(result);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var result = await _mediator.Send(new GetUserQueryRequest(id));
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteUser(DeleteUserCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
