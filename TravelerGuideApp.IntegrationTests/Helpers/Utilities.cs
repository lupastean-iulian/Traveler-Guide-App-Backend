using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;
using TravelerGuideApp.API.DTOs;
using TravelerGuideApp.Domain.Entities;
using TravelerGuideApp.Infrastructure.Database.DatabaseContext;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TravelerGuideApp.IntegrationTests.Helpers
{
    public static class Utilities
    {
        public static void InitializeDbForTests(TravelerGuideAppDBContext db)
        {
            PopulateCitiesTable(db);

            PopulateLocationsTable(db);

            PopulateUsersTable(db);

            PopulateTravelItinerariesTable(db);

            PopulateTravelItineraryLocationsTable(db);
        }
        public static void PopulateCitiesTable(TravelerGuideAppDBContext db)
        {
            string currentPath = Directory.GetCurrentDirectory();
            string txtFilePath = Path.GetFullPath(Path.Combine(currentPath, @"..\..\..\..\TextFiles\Cities.json"));
            var jsonText = File.ReadAllText(txtFilePath);
            List<CityPutPostDto> cities = JsonConvert.DeserializeObject<List<CityPutPostDto>>(jsonText);
            foreach (var item in cities)
            {
                var city = new City(item.Name, item.Country);
                db.Cities.Add(city);
                db.SaveChanges();
            }
        }

        public static void PopulateLocationsTable(TravelerGuideAppDBContext db)
        {
            string currentPath = Directory.GetCurrentDirectory();
            string txtFilePath = Path.GetFullPath(Path.Combine(currentPath, @"..\..\..\..\TextFiles\Locations.json"));
            var jsonText = File.ReadAllText(txtFilePath);
            List<LocationPutPostDto> locations = JsonConvert.DeserializeObject<List<LocationPutPostDto>>(jsonText);
            foreach (var item in locations)
            {
                var location = new Location(item.CityId, item.Name, item.Address,
                    item.Latitude, item.Longitude);
                db.Locations.Add(location);
                db.SaveChanges();
            }
        }
        public static void PopulateUsersTable(TravelerGuideAppDBContext db)
        {
            string currentPath = Directory.GetCurrentDirectory();
            string txtFilePath = Path.GetFullPath(Path.Combine(currentPath, @"..\..\..\..\TextFiles\Users.json"));
            var jsonText = File.ReadAllText(txtFilePath);
            List<UserPutPostDto> users = JsonConvert.DeserializeObject<List<UserPutPostDto>>(jsonText);
            foreach (var item in users)
            {
                var user = new User(item.FirstName, item.LastName, item.Email, item.Password, item.UserType);
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
        public static void PopulateTravelItinerariesTable(TravelerGuideAppDBContext db)
        {
            string currentPath = Directory.GetCurrentDirectory();
            string txtFilePath = Path.GetFullPath(Path.Combine(currentPath, @"..\..\..\..\TextFiles\TravelItineraries.json"));
            var jsonText = File.ReadAllText(txtFilePath);
            List<TravelItineraryPutPostDto> travelItineraries = JsonConvert.DeserializeObject<List<TravelItineraryPutPostDto>>(jsonText);
            foreach (var item in travelItineraries)
            {
                var travelItinerary = new TravelItinerary(item.Name, item.Status, item.TravelDate, item.userId);
                db.TravelItineraries.Add(travelItinerary);
                db.SaveChanges();
            }
        }
        public static void PopulateTravelItineraryLocationsTable(TravelerGuideAppDBContext db)
        {
            string currentPath = Directory.GetCurrentDirectory();
            string txtFilePath = Path.GetFullPath(Path.Combine(currentPath, @"..\..\..\..\TextFiles\TravelItineraryLocations.json"));
            var jsonText = File.ReadAllText(txtFilePath);
            List<TravelItineraryLocationPutPostDto> travelItineraryLocations = JsonConvert.DeserializeObject<List<TravelItineraryLocationPutPostDto>>(jsonText);
            foreach (var item in travelItineraryLocations)
            {
                var travelItineraryLocation = new TravelItineraryLocations(item.TravelItineraryId, item.LocationId);
                db.TravelItineraryLocations.Add(travelItineraryLocation);
                db.SaveChanges();
            }
        }

    }


}
