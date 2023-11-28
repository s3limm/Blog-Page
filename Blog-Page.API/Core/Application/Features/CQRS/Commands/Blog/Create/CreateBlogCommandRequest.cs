using MediatR;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Blog_Page.API.Core.Application.Features.CQRS.Commands.Blog.Create
{
    public class CreateBlogCommandRequest : IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int CategoryID { get; set; }
        public IFormFile FileData { get; set; }
    }
}
