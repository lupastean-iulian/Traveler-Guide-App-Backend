using MediatR;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Interfaces;

namespace TravelerGuideApp.Application.CommandHandlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IUserRepository _repository;

        public DeleteUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<int> Handle(DeleteUserCommand query, CancellationToken cancellationToken)
        {
            _repository.Delete(query.Id);
            _repository.Save();
            return Task.FromResult(query.Id);
        }
    }
}
