namespace TravelerGuideApp.API.DTOs
{
    public class TravelItineraryGetDto
    {
        public int TravelId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime TravelDate { get; set; }
    }
}
