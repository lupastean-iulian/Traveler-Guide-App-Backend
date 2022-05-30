using MediatR;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Application.Queries;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.QueryHandlers
{
    public class GetLocationsForTravelItineraryQueryHandler : IRequestHandler<GetLocationsForTravelItineraryQuery, IEnumerable<Location>>
    {
        private readonly ITravelItineraryLocationsRepository _repository;
        public GetLocationsForTravelItineraryQueryHandler(ITravelItineraryLocationsRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Location>> Handle(GetLocationsForTravelItineraryQuery query,
            CancellationToken cancellationToken)
        {
            var result = _repository.GetLocationsForTravelItinerary(query.travelItineraryId);
            return Task.FromResult(result);
        }
    }

}
