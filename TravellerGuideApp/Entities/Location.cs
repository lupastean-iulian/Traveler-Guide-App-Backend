using System.ComponentModel.DataAnnotations;
namespace TravelerGuideApp.Domain.Entities;
public class Location
{
    private Location()
    {

    }
    public Location(string? name, string? address, string? latitude, string? longitude) : this()
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Address = address ?? throw new ArgumentNullException(nameof(address));
        Latitude = latitude;
        Longitude = longitude;
    }
    public Location(int cityId, string? name, string? address, string? latitude, string? longitude) : this(name, address, latitude, longitude)
    {
        CityId = cityId;
    }

    public int Id { get; set; }
    [MaxLength(150)]
    [Required]
    public string? Name { get; set; }
    [MaxLength(150)]
    [Required]
    public string? Address { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public int? CityId { get; set; }
    public City? City { get; set; } = null;
    public ICollection<TravelItineraryLocations>? TravelItineraryLocations { get; set; }

    public ICollection<UserExperience>? UserExperiences { get; set; }

    public override string ToString()
    {
        return $"{Id} {Name} {Address} {Latitude} {Longitude}";
    }

}
