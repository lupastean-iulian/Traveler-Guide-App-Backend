using Microsoft.EntityFrameworkCore;
using TravelerGuideApp.Domain.Entities;
using TravelerGuideApp.Infrastructure.Database.EF_Core.Entity_Configurations;

namespace TravelerGuideApp.Infrastructure.Database.DatabaseContext
{
    public class TravelerGuideAppDBContext : DbContext
    {
        public TravelerGuideAppDBContext(DbContextOptions<TravelerGuideAppDBContext> options) : base(options)
        {

        }

        public TravelerGuideAppDBContext()
        {

        }


        public DbSet<City?> Cities { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TravelItinerary> TravelItineraries { get; set; }
        public DbSet<TravelItineraryLocations> TravelItineraryLocations { get; set; }

        public DbSet<UserExperience> UserExperiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LocationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TravelItineraryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CityEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TravelItineraryLocationsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserExperienceEntityTypeConfiguration());
        }
    }
}
