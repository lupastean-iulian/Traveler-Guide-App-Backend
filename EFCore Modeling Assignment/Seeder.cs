using System.Globalization;
using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TravelerGuideApp.Application;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Application.Queries;
using TravelerGuideApp.Domain.Entities;
using TravelerGuideApp.Infrastructure.Database.DatabaseContext;
using TravelerGuideApp.Infrastructure.Repositories;

namespace TravelerGuideApp.Presentation
{
    public class Seeder
    {
        public static async Task SeedData()
        {
            var serviceCollection = new ServiceCollection()
                .AddDbContext<TravelerGuideAppDBContext>(options =>
                    options.UseSqlServer("Server=DESKTOP-4NUOG8A;Database=TravelerGuideApp;Trusted_Connection=True;"))
                .AddMediatR(typeof(CreateCityCommand))
                .AddScoped<ICityRepository, CityRepository>()
                .AddScoped<ILocationRepository, LocationRepository>()
                .AddScoped<ITravelItineraryRepository, TravelItineraryRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ITravelItineraryLocationsRepository, TravelItineraryLocationsRepository>()
                .BuildServiceProvider();

            var _mediator = serviceCollection.GetRequiredService<IMediator>();
            foreach (var city in GetPreconfiguredCities())
            {
                await _mediator.Send(new CreateCityCommand { Name = city.Name, Country = city.Country });
            }

            foreach (var user in GetPreconfiguredUsers())
            {
                await _mediator.Send(new CreateUserCommand
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    UserType = user.UserType
                });
            }

            var cities = await _mediator.Send(new GetCitiesListQuery());
            foreach (var location in GetPreConfiguredLocations())
            {
                location.City = cities.First(x => x.Name.Equals(location.Name.Split('-')[1]));
                await _mediator.Send(new CreateLocationCommand
                {
                    Name = location.Name,
                    Address = location.Address,
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                    CityId = location.City.Id
                });
            }



            foreach (var travel in GetPreconfiguredTravelItineraries())
            {
                await _mediator.Send(new CreateTravelItineraryCommand
                {
                    Name = travel.Name,
                    Status = travel.Status,
                    TravelDate = travel.TravelDate,
                    UserId = travel.UserId
                });
            }

            var travelItineraries = await _mediator.Send(new GetTravelItinerariesQuery());
            var locations = await _mediator.Send(new GetLocationsQuery());

            foreach (var travel in travelItineraries)
            {

                var locationsForCity = locations.Join(cities,
                    loc => loc.CityId,
                    city => city.Id,
                    (loc, city) => new
                    {
                        cityName = city.Name,
                        location = loc
                    }).Where(x => x.cityName.Equals(travel.Name.Split('-')[1])).Select(x => x.location);
                foreach (var location in locationsForCity)
                {
                    var command = new AddLocationsToTravelItinerary
                    {
                        TravelItineraryId = travel.Id,
                        LocationId = location.Id,
                    };
                    await _mediator.Send(command);

                }
            }
        }

        private static IEnumerable<City> GetPreconfiguredCities() =>
            new List<City>
            {
                new("Madrid", "Spain"),
                new("Paris", "France"),
                new("London", "United Kingdom"),
                new("Bucuresti", "Romania"),
                new("New York", "USA"),
                new("Berlin", "Germany"),
                new("Los Angeles", "USA"),
                new("Rome", "Italy"),
                new("Prague", "Czech Republic"),
                new("Viena", "Austria")

            };

        private static IEnumerable<User> GetPreconfiguredUsers() =>
            new List<User>
            {
                new("Ion", "Popescu", "ion.popescu@yahoo.com", "12345", "Visitor"),
                new("Iulian", "Lupastean", "ilupastean@yahoo.com", "54321", "Administrator"),
                new("George", "Enescu", "george.enescu@yahoo.com", "password1", "Visitor"),
                new("Maria", "Maiorescu", "maria.maiorescu@yahoo.com", "password2", "Visitor"),
                new("Ion", "Pop", "ion.pop@yahoo.com", "password3", "Visitor"),
                new("Gina", "Popescu", "gina.popescu@yahoo.com", "password4", "Visitor"),
                new("Alexandra", "Popa", "alexandra.popa@gmail.com", "password5", "Visitor"),
                new("Ion", "Popescu", "ion.popescu@yahoo.com", "password6", "Visitor"),
                new("Ioan", "Nascu", "ioan.nascu@yahoo.com", "Password7", "Visitor"),
                new("Elena", "Averescu", "elena.averescu@yahoo.com", "Password7", "Visitor")
            };

        private static IEnumerable<Location> GetPreConfiguredLocations() =>
            new List<Location>
            {
                new("Muzeu1-Madrid", "Adresa1Madrid", "1", "1"),
                new("Muzeu2-Madrid", "AdresaMuzeu2Madrid",  "1", "1"),
                new("Park1-Madrid", "AdresaPark1Madrid",  "1", "1"),
                new("Muzeu1-Paris", "Adresa1Madrid",  "1", "1"),
                new("CasaMemoriala1-Paris", "AdresaCasaMemoriala1Paris", "1", "1"),
                new("Park1-Paris", "AdresaPark1Paris", "1", "1"),
                new("Park1-London", "AdresaPark1Londra", "1", "1"),
                new("Muzeu1-London", "AdresaMuzeu1Londra", "1", "1"),
                new("Casa1Memoriala1-Bucuresti", "AdresaCasaMemoriala1Bucuresti", "1", "1"),
                new("Muzeu1-Bucuresti", "AdresaMuzeu1Bucuresti", "1", "1"),
                new("Muzeu1-New York", "AdresaMuzeu1NewYork", "1", "1"),
                new("CentralPark-New York", "AddressCentralParkNewYork", "1", "1"),
                new("FamousBuilding1-Berlin", "AddressFamousBuilding1Berlin", "1", "1"),
                new("MemorialHouse1-Berlin", "AddressMemorialHouse1Berlin",  "1", "1"),
                new("FamousBuilding1-Rome", "AddressFamousBuilding1Rome", "1", "1"),

            };


        private static IEnumerable<TravelItinerary> GetPreconfiguredTravelItineraries() =>
            new List<TravelItinerary>
            {
                new("Travel1-Madrid", "Completed", DateTime.Parse("12 June 2021", CultureInfo.GetCultureInfo("ro-RO")),
                    1),
                new("Travel1-Paris", "Planned", DateTime.Parse("12 August 2022", CultureInfo.GetCultureInfo("ro-RO")),
                    3),
                new("Travel1-London", "Canceled", DateTime.Parse("12 April 2020", CultureInfo.GetCultureInfo("ro-RO")),
                    7),
                new("Travel1-Bucuresti", "Canceled",
                    DateTime.Parse("29 November 2021", CultureInfo.GetCultureInfo("ro-RO")), 6),
                new("Travel1-USA", "Completed", DateTime.Parse("19 May 2018", CultureInfo.GetCultureInfo("ro-RO")), 8),
                new("Travel1-Berlin", "Planned", DateTime.Parse("31 July 2022", CultureInfo.GetCultureInfo("ro-RO")),
                    3),
                new("Travel2-Madrid", "Canceled", DateTime.Parse("12 August 2021", CultureInfo.GetCultureInfo("ro-RO")),
                    5),
                new("Travel1-Rome", "Planned", DateTime.Parse("18 July 2022", CultureInfo.GetCultureInfo("ro-RO")), 10),
                new("Travel2-London", "Completed", DateTime.Parse("12 April 2022", CultureInfo.GetCultureInfo("ro-RO")),
                    7),
                new("Travel2-Bucuresti", "Canceled",
                    DateTime.Parse("01 December 2021", CultureInfo.GetCultureInfo("ro-RO")), 6),
                new("Travel2-USA", "Completed", DateTime.Parse("19 May 2018", CultureInfo.GetCultureInfo("ro-RO")), 8),
                new("Travel2-Berlin", "Planned",
                    DateTime.Parse("01 September 2022", CultureInfo.GetCultureInfo("ro-RO")), 3)
            };


    }
}
