using System.ComponentModel.DataAnnotations;

namespace TravelerGuideApp.Domain.Entities;

public class TravelItinerary
{
    public TravelItinerary()
    {
    }
    public TravelItinerary(string? name, string? status, DateTime travelDate, int userId)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Status = status ?? throw new ArgumentNullException(nameof(status));
        TravelDate = travelDate;
        UserId = userId;
    }


    public int Id { get; set; }
    [MaxLength(100)]
    [Required]
    public string? Name { get; set; }
    [MaxLength(50)]
    [Required]
    public string? Status { get; set; }
    [Required]
    public DateTime TravelDate { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; } = null;
    public ICollection<TravelItineraryLocations>? TravelItineraryLocations { get; set; }

    public ICollection<UserExperience>? UserExperiences { get; set; }
}
