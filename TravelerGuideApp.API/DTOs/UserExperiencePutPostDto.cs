namespace TravelerGuideApp.API.DTOs
{
    public class UserExperiencePutPostDto
    {
        public int UserId { get; set; }
        public int TravelItineraryId { get; set; }
        public int LocationId { get; set; }
        public string Priority { get; set; }
        public double Budget { get; set; }
        public string Description { get; set; }
    }
}
