using MediatR;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Domain.Entities;
namespace TravelerGuideApp.Application.CommandHandlers
{
    public class GetLocationByLatLngQueryHandler : IRequestHandler<GetLocationByLatLng, Location>
    {
        private readonly ILocationRepository _locationRepository;

        public GetLocationByLatLngQueryHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public Task<Location> Handle(GetLocationByLatLng query, CancellationToken cancellationToken)
        {
            var result = _locationRepository.GetByLatLng(query.lat, query.lng);

            return Task.FromResult(result);
        }

    }
}
