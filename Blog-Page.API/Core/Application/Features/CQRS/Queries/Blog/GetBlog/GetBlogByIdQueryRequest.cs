using Blog_Page.API.Core.Application.Dtos.Blog;
using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Queries.Blog.GetBlog
{
    public class GetBlogByIdQueryRequest : IRequest<BlogListDto>
    {
        public GetBlogByIdQueryRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
