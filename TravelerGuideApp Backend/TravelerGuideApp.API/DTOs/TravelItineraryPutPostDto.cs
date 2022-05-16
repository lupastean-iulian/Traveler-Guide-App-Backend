using System.ComponentModel.DataAnnotations;

namespace TravelerGuideApp.API.DTOs
{
    public class TravelItineraryPutPostDto
    {
        [MaxLength(50)]
        [Required]
        public string? Name { get; set; }
        [MaxLength(30)]
        [Required]
        public string? Status { get; set; }
        public DateTime TravelDate { get; set; }
        public int userId { get; set; }
    }
}
