using Microsoft.EntityFrameworkCore;
using TravelerGuideApp.Application;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Domain.Entities;
using TravelerGuideApp.Infrastructure.Database.DatabaseContext;

namespace TravelerGuideApp.Infrastructure.Repositories
{
    public class CityRepository : ICityRepository, IDisposable
    {
        private readonly TravelerGuideAppDBContext _context;

        public CityRepository(TravelerGuideAppDBContext context)
        {
            this._context = context;
        }

        public void Create(City? city)
        {
            _context.Cities.Add(city);
        }

        public void Update(City city)
        {

            _context.Entry(city).State = EntityState.Modified;

        }

        public void Delete(int cityId)
        {
            var city = _context.Cities.Find(cityId);

            if (city != null)
            {
                _context.Cities.Remove(city);
            }

        }

        public City? GetById(int cityId)
        {
            return _context.Cities.Find(cityId);
        }



        public IEnumerable<City?> GetAll()
        {
            return _context.Cities.ToList();
        }

        public City GetByName(string cityName, string country)
        {
            return _context.Cities.FirstOrDefault(x => x.Name.Equals(cityName) && x.Country.Equals(country));
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public bool Disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (this.Disposed) return;
            if (disposing)
            { _context.Dispose(); }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
