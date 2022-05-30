using System;
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

namespace TravelerGuideApp.IntegrationTests
{
    [TestClass]
    public class TravelItinerariesControllerTests
    {
        private static TestContext _testContext;
        private static WebApplicationFactory<Startup> _factory;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _testContext = testContext;
            _factory = new WebApplicationFactory<Startup>();
        }

        [TestMethod]
        public async Task Get_All_Travel_Itineraries_For_User_ShouldReturnOkStatusCode()
        {
            //Arrange
            var client = _factory.CreateClient();
            var userId = 3;

            //Act
            var response = await client.GetAsync($"api/TravelItinerary/{userId}");

            //Assert 
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }
        [TestMethod]
        public async Task Get_All_Travel_Itineraries_For_User_ShouldReturnNotFoundStatusCode()
        {
            //Arrange
            var client = _factory.CreateClient();
            var userId = 4;

            //Act
            var response = await client.GetAsync($"api/TravelItinerary/{userId}");

            //Assert 
            Assert.IsTrue(response.StatusCode == HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task Get_All_Travel_Itineraries_For_User_ShouldReturnExistingTravelItinerary()
        {
            //Arrange
            var client = _factory.CreateClient();
            var userId = 3;
            var travel = new TravelItineraryGetDto
            {
                TravelId = 2,
                Name = "Travel1-Paris",
                Status = "Planned",
                TravelDate = DateTime.Parse("2022-08-12T00:00:00")
            };

            //Act
            var response = await client.GetAsync($"api/TravelItinerary/{userId}");
            var result = await response.Content.ReadAsStringAsync();
            List<TravelItineraryGetDto> travels = JsonConvert.DeserializeObject<List<TravelItineraryGetDto>>(result);

            //Assert 
            Assert.AreEqual(JsonConvert.SerializeObject(travel), JsonConvert.SerializeObject(travels[0]));
        }

        [TestMethod]
        public async Task Get_TravelItinerary_By_Id_ShouldReturnOkStatusCode()
        {
            //Arrange 
            var travelItineraryId = 3;
            var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync($"api/TravelItinerary/Admin/{travelItineraryId}");

            //Assert 
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }
        [TestMethod]
        public async Task Get_TravelItinerary_By_Id_ShouldReturnNotFoundStatusCode()
        {
            //Arrange 
            var travelItineraryId = 99999;
            var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync($"api/TravelItinerary/Admin/{travelItineraryId}");

            //Assert 
            Assert.IsTrue(response.StatusCode == HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task Create_TravelItinerary_ShouldReturnOkStatusCode()
        {
            //Arrange
            var client = _factory.CreateClient();
            var travelItinerary = new TravelItineraryPutPostDto
            {
                Name = "NewTravel",
                Status = "Completed",
                TravelDate = DateTime.Parse("2022-07-20T00:00:00"),
                userId = 2
            };

            //Act
            var response = await client.PostAsync("/api/TravelItinerary", new StringContent(JsonConvert.SerializeObject(travelItinerary), Encoding.UTF8, "application/json"));

            //Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task Update_TravelItinerary_ShouldReturnOkStatusCode()
        {
            //Arrange 
            var travelItineraryId = 3;
            var client = _factory.CreateClient();
            var updatedTravel = new TravelItineraryPutPostDto
            {
                Name = "UpdatedName",
                Status = "UpdatedStatus",
                TravelDate = DateTime.Parse("2022-08-10"),
                userId = 6
            };

            //Act 
            var response = await client.PutAsync($"api/TravelItinerary/{travelItineraryId}",
                new StringContent(JsonConvert.SerializeObject(updatedTravel), Encoding.UTF8, "application/json"));

            // Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task Update_TravelItinerary_ShouldReturnNotFoundStatusCode()
        {
            //Arrange 
            var travelItineraryId = 99999;
            var client = _factory.CreateClient();
            var updatedTravel = new TravelItineraryPutPostDto
            {
                Name = "UpdatedName",
                Status = "UpdatedStatus",
                TravelDate = DateTime.Parse("2022-08-10"),
                userId = 2
            };

            //Act 
            var response = await client.PutAsync($"api/TravelItinerary/{travelItineraryId}",
                new StringContent(JsonConvert.SerializeObject(updatedTravel), Encoding.UTF8, "application/json"));

            // Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.NotFound);
        }


        [TestMethod]
        public async Task Delete_TravelItinerary_ShouldReturnNoContent()
        {
            //Arrange
            var client = _factory.CreateClient();
            var travelItineraryId = 2;

            //Act
            var response = await client.DeleteAsync($"api/TravelItinerary/{travelItineraryId}");

            //Assert 
            Assert.IsTrue(response.StatusCode == HttpStatusCode.NoContent);

        }
        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }

    }
}
