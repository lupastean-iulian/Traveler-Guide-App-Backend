using MediatR;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.CommandHandlers
{
    public class UpdateUserExperienceCommandHandler : IRequestHandler<UpdateUserExperience, UserExperience>
    {
        private readonly IUserExperience _userExperience;

        public UpdateUserExperienceCommandHandler(IUserExperience userExperience)
        {
            _userExperience = userExperience;
        }

        public Task<UserExperience> Handle(UpdateUserExperience command, CancellationToken cancellationToken)
        {
            var userExp = _userExperience.GetByIds(command.UserId, command.TravelItineraryId, command.LocationId);
            if (userExp == null)
            {
                return Task.FromResult(userExp);
            }
            userExp.Priority = command.Priority;
            userExp.Budget = command.Budget;
            userExp.Description = command.Description;
            _userExperience.UpdateUserExperience(userExp);
            _userExperience.Save();
            return Task.FromResult(userExp);

        }
    }
}
