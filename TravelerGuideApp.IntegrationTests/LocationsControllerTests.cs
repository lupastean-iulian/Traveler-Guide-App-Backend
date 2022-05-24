using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using TravelerGuideApp.API;
using TravelerGuideApp.API.DTOs;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.IntegrationTests.SocialMedia.Host.IntegrationTests;

namespace TravelerGuideApp.IntegrationTests
{
    [TestClass]
    public class LocationsControllerTests
    {
        private static TestContext _testContext;
        private static WebApplicationFactory<Startup> _factory;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _testContext = testContext;
            _factory = new CustomWebApplicationFactory<Startup>();
        }

        [TestMethod]
        public async Task Get_All_Locations_ShouldReturnOkResponse()
        {
            //Arrange 
            var client = _factory.CreateClient();
            //Act 
            var response = await client.GetAsync("api/Cities");
            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Get_All_Locations_ShouldReturnExistingLocation()
        {
            //Arrange
            var location = new LocationGetDto
            {
                LocationId = 1,
                CityId = 1,
                Name = "Muzeu2-Madrid",
                Address = "AdresaMuzeu2Madrid",
                Latitude = "1",
                Longitude = "1"
            };
            var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync("api/Locations");
            var result = await response.Content.ReadAsStringAsync();
            List<LocationGetDto> locations = JsonConvert.DeserializeObject<List<LocationGetDto>>(result);

            //Assert
            Assert.AreEqual(JsonConvert.SerializeObject(location), JsonConvert.SerializeObject(locations[0]));
        }

        [TestMethod]
        public async Task Get_Location_By_Id_ShouldReturnOkStatusCode()
        {
            //Arrange
            var locationId = 1;
            var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync($"api/Locations/{locationId}");

            //Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }
        [TestMethod]
        public async Task Get_Location_By_Id_ShouldReturnNotFoundStatusCode()
        {
            //Arrange
            var locationId = 99999;
            var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync($"api/Locations/{locationId}");

            //Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task Create_Location_ShouldReturnOkStatusCode()
        {
            //Arrange
            var location = new LocationPutPostDto
            {
                CityId = 1,
                Name = "NewLocation",
                Address = "NewLocationAddress",
                Latitude = "1",
                Longitude = "1"
            };
            var client = _factory.CreateClient();
            //Act 
            var response = await client.PostAsync("/api/Locations/Admin",
                new StringContent(JsonConvert.SerializeObject(location), Encoding.UTF8, "application/json"));

            //Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task Update_Location_ShouldReturnOkStatusCode()
        {
            //Arrange
            var locationId = 1;
            var client = _factory.CreateClient();
            var updatedLocation = new UpdateLocationCommand
            {
                CityId = 1,
                Name = "UpdatedLocation",
                Address = "UpdatedLocationAddress",
                Latitude = "1",
                Longitude = "1"
            };
            //Act
            var response = await client.PutAsync($"api/Locations/Admin/{locationId}", new StringContent(JsonConvert.SerializeObject(updatedLocation), Encoding.UTF8, "application/json"));

            //Assert 
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);

        }

        [TestMethod]
        public async Task Update_Location_ShouldReturnNotFoundStatusCode()
        {
            //Arrange
            var locationId = 99999;
            var client = _factory.CreateClient();
            var updatedLocation = new UpdateLocationCommand
            {
                CityId = 1,
                Name = "UpdatedLocation",
                Address = "UpdatedLocationAddress",
                Latitude = "1",
                Longitude = "1"
            };
            //Act
            var response = await client.PutAsync($"api/Locations/Admin/{locationId}",
                new StringContent(JsonConvert.SerializeObject(updatedLocation), Encoding.UTF8, "application/json"));

            //Assert 
            Assert.IsTrue(response.StatusCode == HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task Delete_Location_ShouldReturnNoContent()
        {
            //Arrange
            var locationId = 1;
            var client = _factory.CreateClient();

            //Act
            var response = await client.DeleteAsync($"api/Locations/Admin/{locationId}");

            //Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.NoContent);


        }

        [TestMethod]
        public async Task Delete_Location_ShouldDeleteTravelItineraryLocationsOnThatCity()
        {
            //Arrange
            var locationId = 1;
            var client = _factory.CreateClient();

            // Act 
            await client.DeleteAsync($"api/Locations/Admin/{locationId}");
            var response = await client.GetAsync($"api/TravelItineraryLocation/{locationId}/travelItineraries");
            //Assert 
            Assert.IsTrue(response.StatusCode == HttpStatusCode.NotFound);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }

    }
}
