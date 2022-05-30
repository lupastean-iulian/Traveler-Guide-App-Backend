using MediatR;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = new User(command.FirstName, command.LastName, command.Email, command.Password, command.UserType);
            _repository.Create(user);
            _repository.Save();
            return Task.FromResult(user);
        }
    }
}

