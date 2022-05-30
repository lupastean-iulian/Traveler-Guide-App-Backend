using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Infrastructure.Database.EF_Core.Entity_Configurations
{
    public class TravelItineraryLocationsEntityTypeConfiguration : IEntityTypeConfiguration<TravelItineraryLocations>
    {
        public void Configure(EntityTypeBuilder<TravelItineraryLocations> travelItineraryLocationsConfiguration)
        {
            travelItineraryLocationsConfiguration.HasKey(til => new { til.TravelItineraryId, til.LocationId });
            travelItineraryLocationsConfiguration.HasOne<TravelItinerary>(til => til.TravelItinerary)
                .WithMany(travel => travel.TravelItineraryLocations)
                .HasForeignKey(til => til.TravelItineraryId).OnDelete(DeleteBehavior.Cascade);
            travelItineraryLocationsConfiguration.HasOne<Location>(til => til.Location)
                .WithMany(location => location.TravelItineraryLocations)
                .HasForeignKey(til => til.LocationId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}