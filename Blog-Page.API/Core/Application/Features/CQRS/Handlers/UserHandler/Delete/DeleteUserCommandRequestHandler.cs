using Blog_Page.API.Core.Application.Features.CQRS.Commands.Blog.Delete;
using Blog_Page.API.Core.Application.Features.CQRS.Commands.User.Delete;
using Blog_Page.API.Core.Application.Interfaces;
using Blog_Page.API.Core.Domain;
using MediatR;

namespace Blog_Page.API.Core.Application.Features.CQRS.Handlers.UserHandler.Delete
{
    public class DeleteUserCommandRequestHandler:IRequestHandler<DeleteUserCommandRequest>
    {
        private readonly IRepository<AppUser> _repository;

        public DeleteUserCommandRequestHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id);
            if (data != null)
            {
                await _repository.DeleteAsync(data);
            }
            return Unit.Value;
        }
    }
}
