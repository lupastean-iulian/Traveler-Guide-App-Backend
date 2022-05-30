using Microsoft.EntityFrameworkCore;
using TravelerGuideApp.Application;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Domain.Entities;
using TravelerGuideApp.Infrastructure.Database.DatabaseContext;

namespace TravelerGuideApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private TravelerGuideAppDBContext context;

        public UserRepository(TravelerGuideAppDBContext context)
        {
            this.context = context;
        }

        public void Create(User user)
        {
            context.Users.Add(user);
        }

        public void Update(User user)
        {
            context.Entry(user).State = EntityState.Modified;
        }

        public void Delete(int userId)
        {
            var user = context.Users.Find(userId);
            if (user != null)
            {
                context.Users.Remove(user);
            }
        }

        public User GetById(int userId)
        {
            return context.Users.Find(userId);
        }

        public User GetByEmail(string email)
        {
            return context.Users.FirstOrDefault(x => x.Email.Equals(email));
        }


        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
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
