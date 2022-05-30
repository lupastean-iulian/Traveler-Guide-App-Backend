using System.Collections.Generic;
using System.Linq;
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
using TravelerGuideApp.Domain.Entities;
using TravelerGuideApp.IntegrationTests.SocialMedia.Host.IntegrationTests;

namespace TravelerGuideApp.IntegrationTests
{
    [TestClass]
    public class CityControllerTests
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
        public async Task Get_All_Cities_ShouldReturnOKResponse()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync("api/Cities");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Get_All_Cities_ShouldReturnExistingCity()
        {
            //Arrange
            var client = _factory.CreateClient();
            CityGetDto city = new CityGetDto { Id = 1, Name = "Madrid", Country = "Spain", Locations = new List<LocationPutPostDto>() };

            //Act
            var response = await client.GetAsync("api/Cities");
            var result = await response.Content.ReadAsStringAsync();
            List<CityGetDto> cities = JsonConvert.DeserializeObject<List<CityGetDto>>(result);

            //Assert
            Assert.AreEqual(JsonConvert.SerializeObject(city), JsonConvert.SerializeObject(cities[0]));
        }

        [TestMethod]
        public async Task Get_City_By_Id_ShouldReturnOkStatusCode()
        {
            //Arrange
            var client = _factory.CreateClient();
            var cityId = 1;

            //Act
            var response = await client.GetAsync($"api/Cities/{cityId}");

            //Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);

        }

        [TestMethod]
        public async Task Get_City_By_Id_ShouldReturnNotFoundStatusCode()
        {
            //Arrange 
            var client = _factory.CreateClient();
            var cityId = 99999;

            //Act 
            var response = await client.GetAsync($"api/Cities/{cityId}");

            //Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.NotFound);
        }
        [TestMethod]
        public async Task Create_City_ShouldReturnOKStatusCode()
        {
            //Arrange
            var city = new CreateCityCommand
            {
                Name = "Madrid",
                Country = "Spain"
            };
            var client = _factory.CreateClient();

            //Act
            var response = await client.PostAsync("/api/Cities/Admin", new StringContent(JsonConvert.SerializeObject(city), Encoding.UTF8, "application/json"));

            //Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task Update_City_ShouldReturnOkStatusCode()
        {
            //Arrange
            var cityId = 6;
            var client = _factory.CreateClient();
            var updatedCity = new UpdateCityCommand
            {
                Name = "UpdatedName",
                Country = "UpdatedCountry"
            };

            //Act
            var response = await client.PutAsync($"api/Cities/Admin/{cityId}", new StringContent(JsonConvert.SerializeObject(updatedCity), Encoding.UTF8, "application/json"));

            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);


        }

        [TestMethod]
        public async Task Update_City_ShouldReturnNotFoundStatusCode()
        {
            //Arrange
            var cityId = 99999;
            var client = _factory.CreateClient();
            var updatedCity = new UpdateCityCommand
            {
                Name = "UpdatedName",
                Country = "UpdatedCountry"
            };

            //Act
            var response = await client.PutAsync($"api/Cities/Admin/{cityId}",
                new StringContent(JsonConvert.SerializeObject(updatedCity), Encoding.UTF8, "application/json"));
            Assert.IsTrue(response.StatusCode == HttpStatusCode.NotFound);

        }

        [TestMethod]
        public async Task Delete_City_ShouldReturnNoContent()
        {
            //Arrange
            var cityId = 99999;
            var client = _factory.CreateClient();
            //Act
            var response = await client.DeleteAsync($"api/Cities/Admin/{cityId}");
            Assert.IsTrue(response.StatusCode == HttpStatusCode.NoContent);
        }
        [TestMethod]
        public async Task Delete_City_ShouldDeleteAllLocationsFromCity()
        {
            //Arrange
            int cityId = 1;
            var client = _factory.CreateClient();

            //Act
            await client.DeleteAsync($"api/Cities/Admin/{cityId}");
            var result = await client.GetAsync($"api/Locations/{cityId}/Locations");

            //Assert
            Assert.IsTrue(result.StatusCode == HttpStatusCode.NotFound);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }
    }
}
