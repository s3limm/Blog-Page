using MediatR;

namespace Blog_Page.API.Core.Application.Dtos.User
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsExist { get; set; }
        public string Role { get; set; }
    }
}
