using AutoMapper;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.User.Create;
using Blog_Page.API.Core.Application.Interfaces;
using Blog_Page.API.Core.Domain;
using MediatR;

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
                Role = request.Role,
                Email = request.Email
            });

            return Unit.Value;
        }
    }
}
