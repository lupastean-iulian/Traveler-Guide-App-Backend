using MediatR;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Commands
{
    public class UpdateLocationCommand : IRequest<Location>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public int CityId { get; set; }
    }
}
