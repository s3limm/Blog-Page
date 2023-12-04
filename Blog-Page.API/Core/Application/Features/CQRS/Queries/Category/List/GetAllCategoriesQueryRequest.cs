using Blog_Page.API.Core.Application.Dtos.Category;
using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Queries.Category.List
{
    public class GetAllCategoriesQueryRequest:IRequest<List<CategoryListDto>>
    {
    }
}
