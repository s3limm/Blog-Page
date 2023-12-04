using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Commands.User.Register
{
    public class RegisterUserCommandRequest:IRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
