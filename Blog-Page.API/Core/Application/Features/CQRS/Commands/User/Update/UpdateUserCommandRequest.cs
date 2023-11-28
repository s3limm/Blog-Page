using Blog_Page.API.Core.Application.Enums;
using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Commands.User.Update
{
    public class UpdateUserCommandRequest:IRequest
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
