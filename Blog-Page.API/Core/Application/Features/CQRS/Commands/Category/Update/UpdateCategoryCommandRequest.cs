using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Commands.Category.Update
{
    public class UpdateCategoryCommandRequest:IRequest
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
