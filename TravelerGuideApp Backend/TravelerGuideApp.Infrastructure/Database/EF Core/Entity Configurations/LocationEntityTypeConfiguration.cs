using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Infrastructure.Database.EF_Core.Entity_Configurations
{
    public class LocationEntityTypeConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> locationConfiguration)
        {
            locationConfiguration.HasKey(location => location.Id);
            locationConfiguration.HasOne(location => location.City)
                .WithMany(city => city.Locations).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
