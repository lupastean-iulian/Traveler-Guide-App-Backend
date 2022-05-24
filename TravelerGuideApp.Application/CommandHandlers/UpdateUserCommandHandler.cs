using MediatR;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.CommandHandlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserRepository _repository;

        public UpdateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<User> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = _repository.GetById(command.Id);
            if (user == null)
            {
                return Task.FromResult(user);

            }
            user.FirstName = command.FirstName;
            user.LastName = command.LastName;
            user.Email = command.Email;
            user.Password = command.Password;
            user.UserType = command.UserType;
            _repository.Update(user);
            _repository.Save();
            return Task.FromResult(user);
        }
    }
}
