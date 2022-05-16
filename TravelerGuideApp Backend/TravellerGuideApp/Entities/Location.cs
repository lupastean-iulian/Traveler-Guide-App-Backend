using System.ComponentModel.DataAnnotations;
namespace TravelerGuideApp.Domain.Entities;
public class Location
{
    private Location()
    {

    }
    public Location(string? name, string? address, string? locationType, double price, string? latitude, string? longitude) : this()
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Address = address ?? throw new ArgumentNullException(nameof(address));
        LocationType = locationType ?? throw new ArgumentNullException(nameof(locationType));
        Price = price;
        Latitude = latitude;
        Longitude = longitude;
    }
    public Location(int cityId, string? name, string? address, string? locationType, double price, string? latitude, string? longitude) : this(name, address, locationType, price, latitude, longitude)
    {
        CityId = cityId;
    }

    public int Id { get; set; }
    [MaxLength(50)]
    [Required]
    public string? Name { get; set; }
    [MaxLength(50)]
    [Required]
    public string? Address { get; set; }
    [MaxLength(50)]
    [Required]
    public string? LocationType { get; set; }
    public double Price { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public int? CityId { get; set; }
    public City? City { get; set; } = null;
    public ICollection<TravelItineraryLocations>? TravelItineraryLocations { get; set; }

    public override string ToString()
    {
        return $"{Id} {Name} {Address} {LocationType} {Price} {Latitude} {Longitude}";
    }

}
