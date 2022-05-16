using MediatR;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Interfaces;

namespace TravelerGuideApp.Application.CommandHandlers
{
    public class AddLocationsToTravelItineraryCommandHandler : IRequestHandler<AddLocationsToTravelItinerary, int>
    {
        private readonly ITravelItineraryLocationsRepository _travelItineraryLocationsRepository;

        public AddLocationsToTravelItineraryCommandHandler(ITravelItineraryLocationsRepository travelItineraryLocatuinsRepository)
        {
            _travelItineraryLocationsRepository = travelItineraryLocatuinsRepository;
        }

        public Task<int> Handle(AddLocationsToTravelItinerary command, CancellationToken cancellationToken)
        {
            _travelItineraryLocationsRepository.CreateTravelItineraryLocation(command.TravelItineraryId, command.LocationId);
            _travelItineraryLocationsRepository.Save();
            return Task.FromResult(command.TravelItineraryId);

        }
    }
}