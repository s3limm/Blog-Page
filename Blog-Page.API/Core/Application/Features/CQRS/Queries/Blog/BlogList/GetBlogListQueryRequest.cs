using Blog_Page.API.Core.Application.Dtos;
using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Queries.Blog.BlogList
{
    public class GetBlogListQueryRequest : IRequest<List<BlogListDto>>
    {
    }
}
