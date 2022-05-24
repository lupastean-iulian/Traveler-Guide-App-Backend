using Microsoft.EntityFrameworkCore;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Domain.Entities;
using TravelerGuideApp.Infrastructure.Database.DatabaseContext;

namespace TravelerGuideApp.Infrastructure.Repositories
{
    public class TravelItineraryRepository : ITravelItineraryRepository, IDisposable
    {
        private TravelerGuideAppDBContext context;

        public TravelItineraryRepository(TravelerGuideAppDBContext context)
        {
            this.context = context;
        }

        public void Create(TravelItinerary travelItinerary)
        {
            context.TravelItineraries.Add(travelItinerary);
        }



        public void CreateTravelItineraryLocation(TravelItinerary travelItinerary, Location Location)
        {
            context.TravelItineraryLocations.Add(new TravelItineraryLocations
            {
                TravelItineraryId = travelItinerary.Id,
                LocationId = Location.Id,
                TravelItinerary = travelItinerary,
                Location = Location,
            });
        }

        public void Update(TravelItinerary travelItinerary)
        {
            context.Entry(travelItinerary).State = EntityState.Modified;
        }

        public void Delete(int travelItineraryId)
        {
            var travelItinerary = context.TravelItineraries.Find(travelItineraryId);
            if (travelItinerary != null)
            {
                context.TravelItineraries.Remove(travelItinerary);
            }
        }


        public IEnumerable<TravelItinerary> GetAll(int userId)
        {
            return context.TravelItineraries.Where(x => x.UserId == userId).Select(x => x).ToList();
        }

        public TravelItinerary GetById(int travelItineraryId)
        {
            return context.TravelItineraries.Find(travelItineraryId);
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
