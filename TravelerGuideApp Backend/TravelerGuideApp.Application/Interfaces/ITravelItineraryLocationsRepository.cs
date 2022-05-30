using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Interfaces
{
    public interface ITravelItineraryLocationsRepository
    {
        public void CreateTravelItineraryLocation(int travelItineraryId, int locationId);
        public void DeleteTravelItineraryLocation(int travelItineraryId, int locationId);

        public IEnumerable<Location> GetLocationsForTravelItinerary(int travelItineraryId);
        public IEnumerable<TravelItinerary> GeTravelItinerariesForLocation(int locationId);
        public void Save();
    }
}
