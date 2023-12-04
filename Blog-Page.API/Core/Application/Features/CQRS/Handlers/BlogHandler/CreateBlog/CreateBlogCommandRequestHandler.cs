using Blog_Page.API.Core.Application.Features.CQRS.Commands.Blog.Create;
using Blog_Page.API.Core.Application.Interfaces;
using Blog_Page.API.Core.Domain;
using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Handlers.BlogHandler.CreateBlog
{
    public class CreateBlogCommandRequestHandler : IRequestHandler<CreateBlogCommandRequest>
    {
        private readonly IRepository<Blog> _repository;

        public CreateBlogCommandRequestHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateBlogCommandRequest request, CancellationToken cancellationToken)
        {
            byte[] fileData = await ConvertFormFileToByteArrayAsync(request.FileData);

            await _repository.CreateAsync(new Blog
            {
                Title = request.Title,
                Description = request.Description,
                Content = request.Content,
                CategoryID = request.CategoryID,
                FileData = fileData,
                CreatedDate = DateTime.UtcNow,
                Status = Enums.Status.Inserted
            });
           ;

            return Unit.Value;
        }

        private async Task<byte[]> ConvertFormFileToByteArrayAsync(IFormFile file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
