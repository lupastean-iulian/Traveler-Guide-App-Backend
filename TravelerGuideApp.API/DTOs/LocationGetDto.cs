using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.API.DTOs
{
    public class LocationGetDto
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int CityId { get; set; }
    }
}
