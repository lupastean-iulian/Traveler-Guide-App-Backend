using MediatR;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Application.Queries;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.QueryHandlers
{
    public class GetTravelItineraryByIdQueryHandler : IRequestHandler<GetTravelItineraryByIdQuery, TravelItinerary>
    {
        private readonly ITravelItineraryRepository _repository;

        public GetTravelItineraryByIdQueryHandler(ITravelItineraryRepository repository)
        {
            _repository = repository;
        }

        public Task<TravelItinerary> Handle(GetTravelItineraryByIdQuery query, CancellationToken cancellationToken)
        {
            var result = _repository.GetById(query.Id);

            return Task.FromResult(result);
        }

    }
}