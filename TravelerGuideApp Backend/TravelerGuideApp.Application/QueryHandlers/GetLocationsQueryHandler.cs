using MediatR;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Application.Queries;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.QueryHandlers
{
    public class GetLocationsQueryHandler : IRequestHandler<GetLocationsQuery, IEnumerable<Location>>
    {
        private readonly ILocationRepository _repository;

        public GetLocationsQueryHandler(ILocationRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Location>> Handle(GetLocationsQuery query, CancellationToken cancellationToken)
        {
            var result = _repository.GetLocations();

            return Task.FromResult(result);
        }
    }
}
