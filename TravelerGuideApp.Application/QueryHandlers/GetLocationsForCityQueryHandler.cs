using MediatR;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Application.Queries;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.QueryHandlers
{
    public class GetLocationsForCityQueryHandler : IRequestHandler<GetLocationsForCity, IEnumerable<Location>>
    {
        private readonly ILocationRepository _repository;

        public GetLocationsForCityQueryHandler(ILocationRepository repository)
        {
            _repository = repository;

        }

        public Task<IEnumerable<Location>> Handle(GetLocationsForCity query, CancellationToken cancellationToken)
        {
            var result = _repository.GetLocationsForCity(query.CityId);
            return Task.FromResult(result);
        }

    }
}
