using AutoMapper;
using Blog_Page.API.Core.Application.Dtos.User;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.Blog.Create;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.Blog.Delete;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.Blog.Update;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.User.Create;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.User.Delete;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.User.Register;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.User.Update;
using Blog_Page.API.Core.Application.Features.CQRS.Queries.Blog.BlogList;
using Blog_Page.API.Core.Application.Features.CQRS.Queries.Blog.GetBlog;
using Blog_Page.API.Core.Application.Features.CQRS.Queries.User.CheckUser;
using Blog_Page.API.Core.Application.Features.CQRS.Queries.User.Get;
using Blog_Page.API.Core.Application.Features.CQRS.Queries.User.List;
using Blog_Page.API.Core.Application.Interfaces;
using Blog_Page.API.Infrastructure.Tools.JwtTokenGenerator;
using Blog_Page.API.Persistance.Repositories;
using Blog_Page.Domain.BlogPage.Dtos.User;
using Blog_Page.Domain.Entities;
using Blog_Page.Model.User.Request;
using Blog_Page.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetListAsync()
        {
            var data = await _service.GetListAsync(); 
            return Ok(data);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var data = await _service.FindAsync(id);
            return Ok(data);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CreateUserRequest request)
        {
            await _service.CreateAsync(new CreateUserDto
            {
                userName = request.userName,
                Password = request.Password,
                Email = request.Email,
                AppRoleId = request.AppRoleId
            });
            return Created("", request.userName);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var data = await _service.FindAsync(id);
            if(data!=null)
            {
                await _service.DeleteAsync(data);
            }
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(UpdateUserRequest request)
        {
            var data = await _service.FindAsync(request.Id);
            if(data!=null)
            {
                data.userName = request.userName;
                data.Password = request.Password;
                data.Email = request.Email;
                //data.AppRoleId = (AppRole)request.Role;
            }
            var mappedData = _mapper.Map<UpdateUserDto>(data);
            await _service.UpdateAsync(mappedData);
            return Ok(data.userName);
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDto request)
        {
            await _service.CreateAsync(new CreateUserDto
            {
                userName = request.userName,
                Password = request.Password,
                Email = request.Email,
                AppRoleId = request.AppRoleId
            });
            return Created("", request.userName);
        }


        [HttpPost("login")]

        public async Task<IActionResult> Login(CheckUserRequest request)
        {
            var dto = new CheckUserDto();
            var user = await _service.GetByFilterAsync(x => x.userName == request.UserName && x.Password == request.Password);
            if (user == null)
            {
                dto.IsExist = false;
            }
            else
            {
                dto.IsExist = true;
                dto.UserName = user.userName;
                dto.Password = user.Password;
                //var role = await this._service.GetByFilterAsync(x => x.AppRoleId == user.AppRoleId);
                //dto.Role = role?.definition;
            }

            if (dto != null)
            {
                return Created("", JwtTokenGenerator.GenerateToken(dto));
            }
            else
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }
        }
    }
}
