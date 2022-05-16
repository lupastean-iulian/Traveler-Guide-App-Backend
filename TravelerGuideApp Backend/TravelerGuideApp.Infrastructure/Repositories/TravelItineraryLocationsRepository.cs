using Microsoft.EntityFrameworkCore;
using System.Linq;
using TravelerGuideApp.Application;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Domain.Entities;
using TravelerGuideApp.Infrastructure.Database.DatabaseContext;

namespace TravelerGuideApp.Infrastructure.Repositories
{
    public class TravelItineraryLocationsRepository : ITravelItineraryLocationsRepository, IDisposable
    {
        private readonly TravelerGuideAppDBContext context;

        public TravelItineraryLocationsRepository(TravelerGuideAppDBContext context)
        {
            this.context = context;
        }


        public void CreateTravelItineraryLocation(int travelItineraryId, int locationId)
        {
            var travelItinerary = context.TravelItineraries.Find(travelItineraryId);
            var location = context.Locations.Find(locationId);
            if (travelItinerary != null && location != null)
            {
                context.TravelItineraryLocations.Add(new TravelItineraryLocations
                {
                    TravelItineraryId = travelItinerary.Id,
                    LocationId = location.Id,
                    TravelItinerary = travelItinerary,
                    Location = location,
                });
            }
        }


        public void DeleteTravelItineraryLocation(int travelItineraryId, int LocationId)
        {
            var travelItineraryLocation = context.TravelItineraryLocations.Find(travelItineraryId, LocationId);
            if (travelItineraryLocation != null)
            {
                context.TravelItineraryLocations.Remove(travelItineraryLocation);
            }
        }

        public IEnumerable<Location> GetLocationsForTravelItinerary(int travelItineraryId)
        {
            return context.Locations.Where(location =>
                location.TravelItineraryLocations.Any(travelItineraries => travelItineraries.TravelItineraryId == travelItineraryId)).AsEnumerable();
        }

        public IEnumerable<TravelItinerary> GeTravelItinerariesForLocation(int locationId)
        {
            return context.TravelItineraries.Where(travelItinerary =>
                travelItinerary.TravelItineraryLocations.Any(location => location.LocationId == locationId)).AsEnumerable();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}