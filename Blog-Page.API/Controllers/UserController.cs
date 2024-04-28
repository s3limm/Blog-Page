using AutoMapper;
using Blog_Page.API.Infrastructure.Tools.JwtTokenGenerator;
using Blog_Page.Domain.BlogPage.Dtos.User;
using Blog_Page.Domain.Entities;
using Blog_Page.Model.User.Request;
using Blog_Page.Service.Interfaces;
using Blog_Page.Service.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Page.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<AppUser> _service;
        private readonly IRepository<AppRole> _roleService;
        private readonly IMapper _mapper;

        public UserController(IRepository<AppUser> service, IMapper mapper, IRepository<AppRole> roleService)
        {
            _service = service;
            _mapper = mapper;
            _roleService = roleService;
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
            var data = await _service.GetAsync(id);
            return Ok(data);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CreateUserRequest request)
        {
            await _service.CreateAsync(new AppUser
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
            var data = await _service.GetAsync(id);
            if (data != null)
            {
                await _service.DeleteAsync(data);
            }
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(UpdateUserRequest request)
        {
            var data = await _service.GetAsync(request.Id);
            if (data != null)
            {
                data.userName = request.userName;
                data.Password = request.Password;
                data.Email = request.Email;
                data.AppRoleId = Convert.ToInt32(request.Role);
            }
            await _service.UpdateAsync(data);
            return Ok(data.userName);
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDto request)
        {
            await _service.CreateAsync(new AppUser
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
            var user = await _service.GetByFilterAsync(x => x.userName == request.userName && x.Password == request.passWord);
            if (user != null)
            {
                dto.IsExist = true;
                dto.UserName = user.userName;
                dto.Password = user.Password;
                var role = await _roleService.GetByFilterAsync(x => x.Id == user.AppRoleId);
                dto.Definition = role.Definition;
                dto.Id = user.ID;
                dto.Email = user.Email;
            }

            if (dto != null && user != null)
            {
                return Created("",JwtTokenGenerator.GenerateToken(dto));
            }
            else
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }
        }
    }
}
