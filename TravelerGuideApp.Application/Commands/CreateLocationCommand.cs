
using MediatR;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Commands
{
    public class CreateLocationCommand : IRequest<Location>
    {
        public int CityId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
    }
}
