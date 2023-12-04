using Blog_Page.API.Core.Application.Features.CQRS.Commands.Category.Update;
using Blog_Page.API.Core.Application.Interfaces;
using Blog_Page.API.Core.Domain;
using MediatR;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Blog_Page.API.Core.Application.Features.CQRS.Handlers.CategoryHandler.UpdateCategory
{
    public class UpdateCategoryCommandRequestHandler : IRequestHandler<UpdateCategoryCommandRequest>
    {
        private readonly IRepository<Category> repository;

        public UpdateCategoryCommandRequestHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.Id);
            if(data != null)
            {
                data.CategoryName = request.CategoryName;
                data.Status = Enums.Status.Updated;
                data.ModifiedDate = DateTime.UtcNow;
            }
            await repository.UpdateAsync(data);
            return Unit.Value;
        }
    }
}
