using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Commands.User.Delete
{
    public class DeleteUserCommandRequest:IRequest
    {
        public DeleteUserCommandRequest(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
