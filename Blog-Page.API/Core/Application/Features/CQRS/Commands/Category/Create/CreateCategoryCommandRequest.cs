using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Commands.Category.Create
{
    public class CreateCategoryCommandRequest:IRequest
    {
        public string CategoryName { get; set; }
    }
}
