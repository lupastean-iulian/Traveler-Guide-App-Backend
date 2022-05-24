using System.ComponentModel.DataAnnotations;
namespace TravelerGuideApp.Domain.Entities;
public class City
{
    private City()
    {

    }
    public City(string? name, string? country)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Country = country ?? throw new ArgumentNullException(nameof(country));
    }

    public City(int id, string name, string country, ICollection<Location>? locations) : this(name, country)
    {
        Id = id;
        Locations = locations;
    }

    public int Id { get; set; }
    [MaxLength(50)]
    [Required]
    public string Name { get; set; }
    [MaxLength(50)]
    [Required]
    public string? Country { get; set; }
    public ICollection<Location>? Locations { get; set; }

    public override string ToString()
    {
        return $" {Id} {Name} {Country}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is not City city)
        {
            return false;
        }
        else
        {
            return Id == city.Id && Name == city.Name && Country == city.Country;
        }
    }
}
