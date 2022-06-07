using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Interfaces
{
    public interface ILocationRepository
    {
        void Create(Location location);
        void Update(Location location);
        void Delete(int locationId);
        Location GetById(int locationId);

        Location GetByLatLng(string lat, string lng);
        IEnumerable<Location> GetLocations();
        IEnumerable<Location> GetLocationsForCity(int cityId);
        Location GetByAddress(string address);
        public void Save();
    }
}
