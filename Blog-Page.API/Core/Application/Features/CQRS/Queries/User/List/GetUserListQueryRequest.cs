

using Blog_Page.API.Core.Application.Dtos;
using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Queries.User.List
{
    public class GetUserListQueryRequest : IRequest<List<AppUserListDto>>
    {
    }
}
