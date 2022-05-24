using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.API.DTOs
{
    public class CityGetDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public ICollection<LocationPutPostDto>? Locations { get; set; }

    }
}
