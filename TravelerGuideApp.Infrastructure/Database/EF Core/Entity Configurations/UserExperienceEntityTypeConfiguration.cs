using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Infrastructure.Database.EF_Core.Entity_Configurations
{
    public class UserExperienceEntityTypeConfiguration : IEntityTypeConfiguration<UserExperience>
    {
        public void Configure(EntityTypeBuilder<UserExperience> userExperienceConfiguration)
        {
            userExperienceConfiguration.HasKey(ue => new { ue.UserId, ue.TravelItineraryId, ue.LocationId });
            userExperienceConfiguration.HasOne<User>(ue => ue.User).WithMany(user => user.UserExperiences)
                .HasForeignKey(ue => ue.UserId).OnDelete(DeleteBehavior.NoAction);
            userExperienceConfiguration.HasOne<TravelItinerary>(ue => ue.TravelItinerary)
                .WithMany(ti => ti.UserExperiences).HasForeignKey(ue => ue.TravelItineraryId)
                .OnDelete(DeleteBehavior.Cascade);
            userExperienceConfiguration.HasOne<Location>(ue => ue.Location)
                .WithMany(locations => locations.UserExperiences).HasForeignKey(location => location.LocationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
