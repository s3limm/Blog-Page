using AutoMapper;
using Blog_Page.API.Core.Application.Dtos.User;
using Blog_Page.API.Core.Application.Features.CQRS.Queries.User.Get;
using Blog_Page.API.Core.Application.Features.CQRS.Queries.User.List;
using Blog_Page.API.Core.Application.Interfaces;
using Blog_Page.API.Core.Domain;
using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Handlers.UserHandler.GetUser
{
    public class GetUserQueryRequestHandler : IRequestHandler<GetUserQueryRequest, AppUserListDto>
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IMapper _mapper;

        public GetUserQueryRequestHandler(IRepository<AppUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<AppUserListDto> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByFilterAsync(x=>x.ID == request.Id);
            return _mapper.Map<AppUserListDto>(data);
        }
    }
}
