using AutoMapper;
using Blog_Page.API.Core.Application.Dtos.User;
using Blog_Page.API.Core.Application.Features.CQRS.Queries.User.List;
using Blog_Page.API.Core.Application.Interfaces;
using Blog_Page.API.Core.Domain;
using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Handlers.UserHandler.List
{
    public class GetUserListQueryRequestHandler : IRequestHandler<GetUserListQueryRequest, List<AppUserListDto>>
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IMapper _mapper;

        public GetUserListQueryRequestHandler(IRepository<AppUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<AppUserListDto>> Handle(GetUserListQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllListAsync();
            return _mapper.Map<List<AppUserListDto>>(data);
        }
    }
}
