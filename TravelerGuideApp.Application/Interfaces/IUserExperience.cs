
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Interfaces
{
    public interface IUserExperience
    {
        void CreateUserExperience(UserExperience userExperience);

        void DeleteUserExperience(int userId, int travelItineraryId, int locationId);

        void UpdateUserExperience(UserExperience userExperience);
        UserExperience GetByIds(int userId, int travelItineraryId, int locationId);
        UserExperience GetSpecificUserExperience(int userId, int travelItineraryId, int locationId);
        public void Save();
    }
}

