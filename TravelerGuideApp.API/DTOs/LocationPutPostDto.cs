using System.ComponentModel.DataAnnotations;

namespace TravelerGuideApp.API.DTOs
{
    public class LocationPutPostDto
    {
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [MaxLength(40)]
        [MinLength(10)]
        public string Address { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string Latitude { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string Longitude { get; set; }
        public int CityId { get; set; }
    }
}
