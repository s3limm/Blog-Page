using Blog_Page.API.Core.Application.Features.CQRS.Commands.Category.Delete;
using Blog_Page.API.Core.Application.Interfaces;
using Blog_Page.API.Core.Domain;
using MediatR;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Blog_Page.API.Core.Application.Features.CQRS.Handlers.CategoryHandler.DeleteCategory
{
    public class DeleteCategoryCommandRequestHandler : IRequestHandler<DeleteCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repository;

        public DeleteCategoryCommandRequestHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id);
            if (data != null)
            {
                await _repository.DeleteAsync(data);
            }
            return Unit.Value;
        }
    }
}
