using Blog_Page.API.Core.Application.Dtos;
using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Queries.Category.Get
{
    public class GetCategoryByIdQueryRequest:IRequest<CategoryListDto>
    {
        public GetCategoryByIdQueryRequest(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
