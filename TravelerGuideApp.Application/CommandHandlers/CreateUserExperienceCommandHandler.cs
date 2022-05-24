using MediatR;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.CommandHandlers
{
    public class CreateUserExperienceCommandHandler : IRequestHandler<CreateUserExperience, UserExperience>
    {
        private readonly IUserExperience _userExperience;

        public CreateUserExperienceCommandHandler(IUserExperience userExperience)
        {
            _userExperience = userExperience;
        }

        public Task<UserExperience> Handle(CreateUserExperience command, CancellationToken cancellationToken)
        {
            var userExperience = new UserExperience
            {
                UserId = command.UserId,
                TravelItineraryId = command.TravelItineraryId,
                LocationId = command.LocationId,
                Priority = command.Priority,
                Budget = command.Budget,
                Description = command.Description
            };

            _userExperience.CreateUserExperience(userExperience);
            _userExperience.Save();
            return Task.FromResult(userExperience);
        }
    }
}
