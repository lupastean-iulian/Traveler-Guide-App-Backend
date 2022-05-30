using MediatR;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Application.Queries;
using TravelerGuideApp.Domain.Entities;


namespace TravelerGuideApp.Application.QueryHandlers
{
    public class GetTravelItinerariesForLocationQueryHandler : IRequestHandler<GetTravelItinerariesForLocationQuery, IEnumerable<TravelItinerary>>
    {
        private readonly ITravelItineraryLocationsRepository _repository;

        public GetTravelItinerariesForLocationQueryHandler(ITravelItineraryLocationsRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<TravelItinerary>> Handle(GetTravelItinerariesForLocationQuery query,
            CancellationToken cancellationToken)
        {
            var result = _repository.GeTravelItinerariesForLocation(query.locationId);
            return Task.FromResult(result);
        }
    }
}
