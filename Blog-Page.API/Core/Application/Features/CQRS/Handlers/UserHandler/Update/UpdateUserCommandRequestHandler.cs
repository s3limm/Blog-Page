using Blog_Page.API.Core.Application.Features.CQRS.Commands.Blog.Update;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.User.Update;
using Blog_Page.API.Core.Application.Interfaces;
using Blog_Page.API.Core.Domain;
using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Handlers.UserHandler.Update
{
    public class UpdateUserCommandRequestHandler : IRequestHandler<UpdateUserCommandRequest>
    {
        private readonly IRepository<AppUser> _repository;

        public UpdateUserCommandRequestHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id);
            if (data != null)
            {
                data.userName = request.userName;
                data.Email = request.Email;
                data.Password = request.Password;
                data.Status = Enums.Status.Updated;
                data.ModifiedDate = DateTime.UtcNow;
            }
            await _repository.UpdateAsync(data);
            return Unit.Value;
        }
    }
}