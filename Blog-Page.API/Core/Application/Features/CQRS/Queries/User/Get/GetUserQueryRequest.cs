using Blog_Page.API.Core.Application.Dtos;
using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Queries.User.Get
{
    public class GetUserQueryRequest : IRequest<AppUserListDto>
    {
        public GetUserQueryRequest(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
