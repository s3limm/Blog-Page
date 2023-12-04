using Blog_Page.API.Core.Application.Dtos.User;
using Blog_Page.API.Core.Application.Features.CQRS.Queries.User.CheckUser;
using Blog_Page.API.Core.Application.Interfaces;
using Blog_Page.API.Core.Domain;
using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Handlers.UserHandler.CheckUser
{
    public class CheckUserQueryRequestHandler : IRequestHandler<CheckUserQueryRequest, UserResponseDto>
    {
        private readonly IRepository<AppUser> repository;
        private readonly IRepository<AppRole> roleRepository;

        public CheckUserQueryRequestHandler(IRepository<AppUser> repository, IRepository<AppRole> roleRepository)
        {
            this.repository = repository;
            this.roleRepository = roleRepository;
        }

        public async Task<UserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new UserResponseDto();
            var user = await repository.GetByFilterAsync(x => x.userName == request.UserName && x.Password == request.Password);
            if (user == null)
            {
                dto.IsExist = false;
            }
            else
            {
                dto.IsExist = true;
                dto.UserName = user.userName;
                dto.Password = user.Password;
                var role = await this.roleRepository.GetByFilterAsync(x => x.Id == user.AppRoleId);
                dto.Role = role?.Definition;
            }
            return dto;
        }
    }
}
