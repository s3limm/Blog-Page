using Blog_Page.API.Core.Application.Features.CQRS.Commands.Blog.Delete;
using Blog_Page.API.Core.Application.Interfaces;
using Blog_Page.API.Core.Domain;
using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Handlers.BlogHandler.DeleteBlog
{
    public class DeleteBlogCommandRequestHandler : IRequestHandler<DeleteBlogCommandRequest>
    {
        private readonly IRepository<Blog> _repository;

        public DeleteBlogCommandRequestHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteBlogCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id);
            if(data != null)
            {
                await _repository.DeleteAsync(data);
            }
            return Unit.Value;
        }
    }
}
