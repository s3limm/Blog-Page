using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Commands.Blog.Update
{
    public class UpdateBlogCommandRequest:IRequest
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int CategoryID { get; set; }
    }
}
