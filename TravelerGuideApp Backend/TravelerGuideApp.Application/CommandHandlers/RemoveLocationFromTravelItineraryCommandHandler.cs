using MediatR;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Interfaces;

namespace TravelerGuideApp.Application.CommandHandlers
{
    public class RemoveLocationFromTravelItineraryCommandHandler : IRequestHandler<RemoveLocationFromTravelitinerary, int>
    {
        private readonly ITravelItineraryLocationsRepository _repository;

        public RemoveLocationFromTravelItineraryCommandHandler(ITravelItineraryLocationsRepository repository)
        {
            _repository = repository;
        }

        public Task<int> Handle(RemoveLocationFromTravelitinerary command, CancellationToken cancellationToken)
        {
            _repository.DeleteTravelItineraryLocation(command.travelItineraryId, command.LocationId);
            _repository.Save();
            return Task.FromResult(command.travelItineraryId);
        }
    }
}
