using MediatR;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Domain.Entities;
using TravelerGuideApp.Infrastructure.Database.DatabaseContext;
using TravelerGuideApp.Infrastructure.Repositories;

namespace TravelerGuideApp.Presentation
{

    public static class Program
    {
        //public static void AveragePriceToVisitEachCity(TravelerGuideAppDBContext context)
        //{
        //    var query1 = from city in context.Cities
        //                 join location in context.Locations on city.Id equals location.CityId
        //                 group location by city.Name into grp
        //                 select new
        //                 {
        //                     CityName = grp.Key,
        //                     AveragePrice = grp.Average(location => location.Price)
        //                 };
        //    foreach (var item in query1)
        //    {
        //        Console.WriteLine($"{item.CityName} {item.AveragePrice}");
        //    }
        //}

        public static void LocationsForCountriesWhosNameStartWithF(TravelerGuideAppDBContext context)
        {
            var query2 = from city in context.Cities
                         join location in context.Locations on city.Id equals location.CityId
                         where city.Country.StartsWith("F")
                         select new { location.Name };

            foreach (var location in query2)
            {
                Console.WriteLine($"{location.Name}");
            }
        }

        //public static void GetAllFamousBuildings(TravelerGuideAppDBContext context)
        //{
        //    var query3 = from city in context.Cities
        //                 join location in context.Locations on city.Id equals location.CityId
        //                 where location.LocationType.Equals("Famous Building")
        //                 select location;
        //    foreach (var location in query3)
        //    {
        //        Console.WriteLine(location);
        //    }
        //}

        public static void GetUsersThatHavePlannedATravel(TravelerGuideAppDBContext context)
        {
            var query4 = from user in context.Users
                         join travel in context.TravelItineraries on user.Id equals travel.UserId
                         where travel.Status.Equals("Planned")
                         select user;
            foreach (var user in query4)
            {
                Console.WriteLine(user);
            }
        }

        public static void UpdateStatusIfTheDateHasPassed(TravelerGuideAppDBContext context)
        {
            //context.TravelItineraries.Add(new TravelItinerary
            //{
            //    Name = "Travel3-Berlin",
            //    Status = "Planned",
            //    TravelDate = DateTime.Parse("2022-04-19"),
            //    UserId = 3

            //});
            (from travels in context.TravelItineraries
             where travels.TravelDate < DateTime.Now && travels.Status.Equals("Planned")
             select travels).ToList().ForEach(i => i.Status = "Canceled");
            context.SaveChanges();
        }

        public static void WhereDoesEachUserPlanToTravel(TravelerGuideAppDBContext context)
        {
            var query6 = from location in context.Locations
                         join travelLocation in context.TravelItineraryLocations on location.Id equals travelLocation.LocationId
                         join travels in context.TravelItineraries on travelLocation.TravelItineraryId equals travels.Id
                         join user in context.Users on travels.UserId equals user.Id
                         where travels.Status.Equals("Planned")
                         select new
                         {
                             UserFirstName = user.FirstName,
                             userLastName = user.LastName,
                             location = location.Name,
                             travelDate = travels.TravelDate
                         };
            foreach (var item in query6)
            {
                Console.WriteLine($"{item.UserFirstName} {item.userLastName} plans to travel to {item.location} on {item.travelDate}");
            }
        }

        //public static void TotalPriceToVisitEachCountry(TravelerGuideAppDBContext context)
        //{
        //    var query7 = from location in context.Locations
        //                 join city in context.Cities on location.CityId equals city.Id
        //                 group location by city.Country
        //        into totalPrice
        //                 select new
        //                 {
        //                     CountryName = totalPrice.Key,
        //                     TotalPrice = totalPrice.Sum(location => location.Price)
        //                 };
        //    foreach (var item in query7)
        //    {
        //        Console.WriteLine($"{item.CountryName} has a total cost of {item.TotalPrice}");
        //    }
        //}

        //public static void PriceToVisitAllMuseums(TravelerGuideAppDBContext context)
        //{
        //    var query8 = from location in context.Locations
        //                 where location.LocationType.Equals("Museum")
        //                 select location.Price;
        //    Console.WriteLine(query8.Sum());
        //}

        public static void NumberOfLocationsForEachCountry(TravelerGuideAppDBContext context)
        {
            var query9 = from city in context.Cities
                         join location in context.Locations on city.Id equals location.CityId
                         group location by city.Country
                into numberOfLocations
                         select new
                         {
                             CountryName = numberOfLocations.Key,
                             numOfLocations = numberOfLocations.Count()
                         };
            foreach (var item in query9)
            {
                Console.WriteLine($"{item.CountryName} as {item.numOfLocations} locations");
            }
        }

        public static void ReplanTravelForSpecificUser(TravelerGuideAppDBContext context)
        {
            (from travel in context.TravelItineraries
             where travel.Status.Equals("Canceled") && travel.UserId.Equals(6)
             select travel).ToList().ForEach(i =>
         {
             i.Status = "Planned";
             i.TravelDate = DateTime.Parse("2022-07-01");
         });
            context.SaveChanges();
        }
        static async Task Main(string[] args)
        {
            //Seeder.SeedData();

            await using var context = new TravelerGuideAppDBContext();

            // 1 Average Price To visit Each City
            //  AveragePriceToVisitEachCity(context);

            //2 Select Locations from Countries That start with F
            //  LocationsForCountriesWhosNameStartWithF(context);

            // 3 Get All the Famous Buildings

            //   GetAllFamousBuildings(context);
            // 4 Get the users that have planned a travel

            //  GetUsersThatHavePlannedATravel(context);
            // 5 update status if travel date has passed
            //  UpdateStatusIfTheDateHasPassed(context);

            // 6 Where Does Each user plan to travel
            //   WhereDoesEachUserPlanToTravel(context);

            // 7 Total Price to Visit 
            //   TotalPriceToVisitEachCountry(context);
            // 8 Total cost to visit all museums
            //  PriceToVisitAllMuseums(context);

            // 9 Number of Locations for each Country
            //   NumberOfLocationsForEachCountry(context);

            //10 Replan a travel that has been canceled for specific user 

            // ReplanTravelForSpecificUser(context);

        }
    }
}
