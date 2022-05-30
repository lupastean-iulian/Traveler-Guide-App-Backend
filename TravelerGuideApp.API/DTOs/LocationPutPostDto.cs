using System.ComponentModel.DataAnnotations;

namespace TravelerGuideApp.API.DTOs
{
    public class LocationPutPostDto
    {
        [Required]
        [MaxLength(150)]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [MaxLength(150)]
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
