
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
    public class UsersControllerTests
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
        public async Task Get_All_Users_ShouldReturnOkStatusCode()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync("api/User");

            //Assert 
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);

        }
        [TestMethod]
        public async Task Get_All_Users_ShouldReturnExistingUser()
        {
            //Arrange
            var client = _factory.CreateClient();
            var user = new UserGetDto
            {
                userId = 1,
                FirstName = "Ion",
                LastName = "Popescu",
                Email = "ion.popescu@yahoo.com",
                UserType = "Visitor",
                TravelItineraries = new List<TravelItineraryPutPostDto>()
            };
            //Act
            var response = await client.GetAsync("api/User");
            var result = await response.Content.ReadAsStringAsync();
            List<UserGetDto> users = JsonConvert.DeserializeObject<List<UserGetDto>>(result);
            //Assert 
            Assert.AreEqual(JsonConvert.SerializeObject(user), JsonConvert.SerializeObject(users[0]));

        }

        [TestMethod]
        public async Task Get_User_By_Id_ShouldReturnOkStatusCode()
        {
            //Arrange
            var client = _factory.CreateClient();
            var userId = 1;

            //Act
            var response = await client.GetAsync($"api/User/{userId}");

            //Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task Get_User_By_Id_ShouldReturnNotFoundStatusCode()
        {
            //Arrange
            var client = _factory.CreateClient();
            var userId = 99999;

            //Act
            var response = await client.GetAsync($"api/User/{userId}");

            //Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task Create_User_ShouldReturnOkStatusCode()
        {
            //Arrange
            var client = _factory.CreateClient();
            var user = new CreateUserCommand
            {
                FirstName = "userFirstName",
                LastName = "userLastName",
                Email = "userEmail@yahoo.com",
                Password = "userPassword",
                UserType = "visitor",
            };

            //Act
            var response = await client.PostAsync("api/User",
                new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

            //Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task Update_User_ShouldReturnOkStatusCode()
        {
            //Arrange
            var client = _factory.CreateClient();
            var userId = 1;
            var updatedUser = new CreateUserCommand
            {
                FirstName = "userFirstName",
                LastName = "userLastName",
                Email = "userEmail@yahoo.com",
                Password = "userPassword",
                UserType = "visitor",
            };

            //Act
            var response = await client.PutAsync($"api/User/{userId}", new StringContent(JsonConvert.SerializeObject(updatedUser), Encoding.UTF8, "application/json"));

            //Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);

        }

        [TestMethod]
        public async Task Update_User_ShouldReturnNotFoundStatusCode()
        {
            //Arrange
            var client = _factory.CreateClient();
            var userId = 99999;
            var updatedUser = new CreateUserCommand
            {
                FirstName = "userFirstName",
                LastName = "userLastName",
                Email = "userEmail@yahoo.com",
                Password = "userPassword",
                UserType = "visitor",
            };

            //Act
            var response = await client.PutAsync($"api/User/{userId}", new StringContent(JsonConvert.SerializeObject(updatedUser), Encoding.UTF8, "application/json"));

            //Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.NotFound);

        }

        [TestMethod]
        public async Task Delete_User_ShouldReturnNoContent()
        {
            //Arrange 
            var client = _factory.CreateClient();
            var userId = 1;

            //Act
            var response = await client.DeleteAsync($"api/User/{userId}");

            //Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.NoContent);
        }

        [TestMethod]
        public async Task Delete_User_ShouldDeleteTravelItinerariesForUser()
        {
            //Arrange 
            var userId = 1;
            var client = _factory.CreateClient();

            //Act
            await client.DeleteAsync($"api/User/{userId}");
            var response = await client.GetAsync($"api/TravelItinerary/user/{userId}");

            //Assert 
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }
    }
}
