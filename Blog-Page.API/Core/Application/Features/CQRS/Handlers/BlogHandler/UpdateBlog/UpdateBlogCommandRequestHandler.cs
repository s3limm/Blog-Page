using Blog_Page.API.Core.Application.Features.CQRS.Commands.Blog.Update;
using Blog_Page.API.Core.Application.Interfaces;
using Blog_Page.API.Core.Domain;
using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Handlers.BlogHandler.UpdateBlog
{
    public class UpdateBlogCommandRequestHandler : IRequestHandler<UpdateBlogCommandRequest>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandRequestHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateBlogCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.ID);
            if(data != null)
            {
                data.CategoryID = request.CategoryID;
                    data.Description = request.Description;
                data.Content = request.Content;
                data.Title = request.Title;
            }
            await _repository.UpdateAsync(data);
            return Unit.Value;
        }
    }
}
