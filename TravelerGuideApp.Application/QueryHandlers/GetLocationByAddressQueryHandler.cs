using MediatR;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.QueryHandlers
{
    public class GetLocationByAddressQueryHandler : IRequestHandler<GetLocationByAddress, Location>
    {
        private readonly ILocationRepository _locationRepository;

        public GetLocationByAddressQueryHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public Task<Location> Handle(GetLocationByAddress query, CancellationToken cancellationToken)
        {
            var result = _locationRepository.GetByAddress(query.Address);

            return Task.FromResult(result);
        }
    }
}
