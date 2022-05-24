using MediatR;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Interfaces;

namespace TravelerGuideApp.Application.CommandHandlers
{
    public class DeleteUserExperienceCommandHandler : IRequestHandler<DeleteUserExperience, int>
    {
        private readonly IUserExperience _userExperience;

        public DeleteUserExperienceCommandHandler(IUserExperience userExperience)
        {
            _userExperience = userExperience;
        }

        public Task<int> Handle(DeleteUserExperience command, CancellationToken cancellationToken)
        {
            _userExperience.DeleteUserExperience(command.UserId, command.TravelItineraryId, command.LocationId);
            _userExperience.Save();
            return Task.FromResult(command.TravelItineraryId);
        }
    }
}
