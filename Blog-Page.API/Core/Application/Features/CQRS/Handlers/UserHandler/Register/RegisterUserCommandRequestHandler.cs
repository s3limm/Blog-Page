using Blog_Page.API.Core.Application.Enums;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.User.Register;
using Blog_Page.API.Core.Application.Interfaces;
using Blog_Page.API.Core.Domain;
using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Handlers.UserHandler.Register
{
    public class RegisterUserCommandRequestHandler : IRequestHandler<RegisterUserCommandRequest>
    {
        private readonly IRepository<AppUser> _repository;

        public RegisterUserCommandRequestHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppUser
            {
                userName = request.UserName,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                AppRoleId = 2,
                Status = Status.Inserted ,
                CreatedDate = DateTime.UtcNow,
            });
            return Unit.Value;
        }
    }
}
