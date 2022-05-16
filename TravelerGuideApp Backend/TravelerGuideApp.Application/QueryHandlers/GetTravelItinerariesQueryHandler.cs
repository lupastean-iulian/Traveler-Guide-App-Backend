using MediatR;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Application.Queries;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.QueryHandlers
{
    public class GetTravelItinerariesQueryHandler : IRequestHandler<GetTravelItinerariesQuery, IEnumerable<TravelItinerary>>
    {
        private readonly ITravelItineraryRepository _repository;

        public GetTravelItinerariesQueryHandler(ITravelItineraryRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<TravelItinerary>> Handle(GetTravelItinerariesQuery query, CancellationToken cancellationToken)
        {
            var result = _repository.GetAll(query.UserId);
            return Task.FromResult(result);
        }
    }
}
