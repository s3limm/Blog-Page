using Blog_Page.API.Core.Application.Features.CQRS.Commands.Category.Create;
using Blog_Page.API.Core.Application.Interfaces;
using Blog_Page.API.Core.Domain;
using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Handlers.CategoryHandler.CreateCategory
{
    public class CreateCategoryCommandRequestHandler : IRequestHandler<CreateCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repository;

        public CreateCategoryCommandRequestHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Category { CategoryName = request.CategoryName , 
                Status = Enums.Status.Inserted, CreatedDate = DateTime.UtcNow}) ;
            return Unit.Value;
        }
    }
}
