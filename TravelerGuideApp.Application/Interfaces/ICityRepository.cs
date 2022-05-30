using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Interfaces
{
    public interface ICityRepository
    {
        void Create(City? city);
        void Update(City? city);
        void Delete(int cityId);
        City? GetById(int cityId);
        IEnumerable<City?> GetAll();
        City GetByName(string cityName, string country);
        public void Save();
    }
}
