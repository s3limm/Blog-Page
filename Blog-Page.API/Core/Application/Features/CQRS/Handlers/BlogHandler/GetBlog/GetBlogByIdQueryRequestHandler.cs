using AutoMapper;
using Blog_Page.API.Core.Application.Dtos;
using Blog_Page.API.Core.Application.Features.CQRS.Queries.Blog.GetBlog;
using Blog_Page.API.Core.Application.Interfaces;
using Blog_Page.API.Core.Domain;
using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Handlers.BlogHandler.GetBlog
{
    public class GetBlogByIdQueryRequestHandler : IRequestHandler<GetBlogByIdQueryRequest, BlogListDto>
    {
        private readonly IRepository<Blog> _repository;
        private readonly IMapper _mapper;

        public GetBlogByIdQueryRequestHandler(IRepository<Blog> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BlogListDto> Handle(GetBlogByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByFilterAsync(x => x.ID == request.Id);
            return _mapper.Map<BlogListDto>(data);
        }
    }
}
