using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Interfaces
{
    public interface ITravelItineraryRepository
    {
        void Create(TravelItinerary travelItinerary);
        void CreateTravelItineraryLocation(TravelItinerary travelItinerary, Location location);
        void Update(TravelItinerary travelItinerary);
        void Delete(int travelItineraryId);
        TravelItinerary GetById(int travelItineraryId);
        IEnumerable<TravelItinerary> GetAll(int userId);
        public void Save();
    }
}
