using AutoMapper;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.User.Create;
using Blog_Page.API.Core.Application.Interfaces;
using Blog_Page.API.Core.Domain;
using MediatR;
using MediatR.Wrappers;

namespace Blog_Page.API.Core.Application.Features.CQRS.Handlers.UserHandler.Create
{
    public class CreateUserCommandRequestHandler : IRequestHandler<CreateUserCommandRequest>
    {
        private readonly IRepository<AppUser> _repository;
      
        public CreateUserCommandRequestHandler(IRepository<AppUser> repository, IMapper mapper)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppUser
            {
                userName = request.userName,
                Password = request.Password,
                Email = request.Email,
                AppRoleId = request.AppRoleId,
                Status = Enums.Status.Inserted,
                CreatedDate = DateTime.UtcNow
            });

            return Unit.Value;
        }
    }
}
