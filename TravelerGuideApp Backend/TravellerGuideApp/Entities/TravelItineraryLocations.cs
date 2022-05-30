namespace TravelerGuideApp.Domain.Entities
{
    public class TravelItineraryLocations
    {
        public int TravelItineraryId { get; set; }
        public int LocationId { get; set; }
        public TravelItinerary TravelItinerary { get; set; }
        public Location Location { get; set; }

        public TravelItineraryLocations()
        {

        }
        public TravelItineraryLocations(int travelItineraryId, int locationId)
        {
            TravelItineraryId = travelItineraryId;
            LocationId = locationId;
        }

    }
}
