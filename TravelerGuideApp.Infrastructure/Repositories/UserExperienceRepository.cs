using Microsoft.EntityFrameworkCore;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Domain.Entities;
using TravelerGuideApp.Infrastructure.Database.DatabaseContext;

namespace TravelerGuideApp.Infrastructure.Repositories
{
    public class UserExperienceRepository : IUserExperience, IDisposable
    {
        private readonly TravelerGuideAppDBContext context;

        public UserExperienceRepository(TravelerGuideAppDBContext context)
        {
            this.context = context;
        }


        public void CreateUserExperience(UserExperience userExperience)
        {
            context.UserExperiences.Add(userExperience);
            //var user = context.Users.Find(userId);
            //var travel = context.TravelItineraries.Find(travelItineraryId);
            //var location = context.Locations.Find(locationId);
            //if (user != null && travel != null && location != null)
            //{
            //    context.UserExperiences.Add(new UserExperience
            //    {
            //        UserId = user.Id,
            //        TravelItineraryId = travel.Id,
            //        LocationId = location.Id,
            //        Priority = priority,
            //        Budget = budget,
            //        Description = description

            //    });
            //}
        }



        public void DeleteUserExperience(int userId, int travelItineraryId, int locationId)
        {
            var userExperience = context.UserExperiences.Find(userId, travelItineraryId, locationId);
            if (userExperience != null)
            {
                context.UserExperiences.Remove(userExperience);
            }
        }

        public void UpdateUserExperience(UserExperience userExperience)
        {
            context.Entry(userExperience).State = EntityState.Modified;
        }

        public UserExperience GetByIds(int userId, int travelItineraryId, int locationId)
        {
            return context.UserExperiences.Find(userId, travelItineraryId, locationId);
        }


        public UserExperience GetSpecificUserExperience(int userId, int travelItineraryId, int locationId)
        {
            return context.UserExperiences.FirstOrDefault(x => x.LocationId == locationId && x.TravelItineraryId == travelItineraryId && x.UserId == userId);
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
