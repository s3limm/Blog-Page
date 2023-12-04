using AutoMapper;
using Blog_Page.API.Core.Application.Dtos.Category;
using Blog_Page.API.Core.Application.Features.CQRS.Queries.Category.List;
using Blog_Page.API.Core.Application.Interfaces;
using Blog_Page.API.Core.Domain;
using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Handlers.CategoryHandler.CategoryList
{
    public class GetCategoryListQueryRequestHandler : IRequestHandler<GetAllCategoriesQueryRequest, List<CategoryListDto>>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetCategoryListQueryRequestHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<CategoryListDto>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
           var data =  await _repository.GetAllListAsync();
            return _mapper.Map<List<CategoryListDto>>(data);   
        }
    }
}
