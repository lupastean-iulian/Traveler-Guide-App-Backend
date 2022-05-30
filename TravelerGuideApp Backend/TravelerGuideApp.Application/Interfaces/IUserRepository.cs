using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Interfaces
{
    public interface IUserRepository
    {
        void Create(User user);
        void Update(User user);
        void Delete(int userId);
        User GetById(int userId);
        User GetByEmail(string email);
        IEnumerable<User> GetAll();
        public void Save();
    }
}
