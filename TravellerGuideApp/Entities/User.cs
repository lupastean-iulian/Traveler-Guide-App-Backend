using System.ComponentModel.DataAnnotations;

namespace TravelerGuideApp.Domain.Entities;

public class User
{
    public User()
    {
    }
    public User(string? firstName, string? lastName, string? email, string? password, string? userType)
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Password = password ?? throw new ArgumentNullException(nameof(password));
        UserType = userType ?? throw new ArgumentNullException(nameof(userType));
    }

    public int Id { get; set; }
    [MaxLength(50)]
    [Required]
    public string? FirstName { get; set; }
    [MaxLength(50)]
    [Required]
    public string? LastName { get; set; }
    [MaxLength(50)]
    [Required]
    public string? Email { get; set; }
    [MaxLength(50)]
    [MinLength(10)]
    [Required]
    public string? Password { get; set; }
    [MaxLength(50)]
    [MinLength(5)]
    [Required]
    public string? UserType { get; set; }
    public ICollection<TravelItinerary>? TravelItineraries { get; set; }
    public ICollection<UserExperience>? UserExperiences { get; set; }

    public override string ToString()
    {
        return $" {Id} {FirstName} {LastName}";
    }
}
