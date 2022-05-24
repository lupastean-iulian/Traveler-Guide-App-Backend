using Microsoft.EntityFrameworkCore;
using TravelerGuideApp.Application;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Domain.Entities;
using TravelerGuideApp.Infrastructure.Database.DatabaseContext;

namespace TravelerGuideApp.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository, IDisposable
    {
        private readonly TravelerGuideAppDBContext context;

        public LocationRepository(TravelerGuideAppDBContext context)
        {
            this.context = context;
        }

        public void Create(Location location)
        {
            context.Locations.Add(location);
        }

        public void Update(Location location)
        {
            context.Entry(location).State = EntityState.Modified;
        }

        public void Delete(int locationId)
        {
            var location = context.Locations.Find(locationId);

            context.Locations.Remove(location);

        }
        public Location GetById(int locationId)
        {
            var location = context.Locations.Find(locationId);

            return location;
        }

        public IEnumerable<Location> GetLocations()
        {
            return context.Locations.ToList();
        }

        public IEnumerable<Location> GetLocationsForCity(int cityId)
        {
            return context.Locations.Where(x => x.CityId == cityId).Select(x => x).ToList();
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
