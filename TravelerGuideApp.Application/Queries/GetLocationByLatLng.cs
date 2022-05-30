using MediatR;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Commands
{
    public class GetLocationByLatLng : IRequest<Location>
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }
}
