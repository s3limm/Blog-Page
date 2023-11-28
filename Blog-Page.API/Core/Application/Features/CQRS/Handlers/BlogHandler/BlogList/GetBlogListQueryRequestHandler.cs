using AutoMapper;
using Blog_Page.API.Core.Application.Dtos;
using Blog_Page.API.Core.Application.Features.CQRS.Queries.Blog.BlogList;
using Blog_Page.API.Core.Application.Interfaces;
using Blog_Page.API.Core.Domain;
using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Handlers.BlogHandler.BlogList
{
    public class GetBlogListQueryRequestHandler : IRequestHandler<GetBlogListQueryRequest, List<BlogListDto>>
    {
        private readonly IRepository<Blog> _repository;
        private readonly IMapper _mapper;

        public GetBlogListQueryRequestHandler(IRepository<Blog> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<BlogListDto>> Handle(GetBlogListQueryRequest request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetAllListAsync();
            return _mapper.Map<List<BlogListDto>>(list);
        }
    }
}
