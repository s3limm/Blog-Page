using Blog_Page.API.Core.Application.Dtos.User;
using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Queries.User.CheckUser
{
    public class CheckUserQueryRequest:IRequest<UserResponseDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
