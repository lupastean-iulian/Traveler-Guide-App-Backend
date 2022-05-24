
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TravelerGuideApp.API.Controllers;
using TravelerGuideApp.API.DTOs;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Queries;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.UnitTests
{
    [TestClass]
    public class LocationControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new();
        private readonly Mock<IMapper> _mockMapper = new();
        [TestMethod]
        public async Task Get_All_Locations_GetLocationsListQueryIsCalled()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<GetLocationsQuery>(), It.IsAny<CancellationToken>())).Verifiable();
            // Act
            var controller = new LocationsController(_mockMapper.Object, _mockMediator.Object);
            await controller.GetAll();
            // Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetLocationsQuery>(), It.IsAny<CancellationToken>()), Times.Once());

        }
        [TestMethod]
        public async Task Get_Location_By_Id_GetLocationByIdQueryIsCalled()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<GetLocationByIdQuery>(), It.IsAny<CancellationToken>())).Verifiable();
            // Act
            var controller = new LocationsController(_mockMapper.Object, _mockMediator.Object);
            await controller.GetById(1);
            // Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetLocationByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }
        [TestMethod]
        public async Task Get_Location_By_Id_GetLocationByIdQueryWithCorrectLocationIdIsCalled()
        {
            var locationId = 1;
            _mockMediator.Setup(m => m.Send(It.IsAny<GetLocationByIdQuery>(), It.IsAny<CancellationToken>()))
                .Returns<GetLocationByIdQuery, CancellationToken>(
                    async (q, c) =>
                    {
                        locationId = q.Id;
                        return await Task.FromResult(new Location(locationId, "Muzeu1-Madrid", "Adresa1Madrid", "1", "1"));
                    });
        }

        [TestMethod]
        public async Task Get_Location_By_Id_GetLocationByIdReturnsNotFound()
        {
            //Arrange

            var location = new Location(3, "LocationName", "LocationAddress", "1", "1");
            _mockMediator.Setup(m => m.Send(It.IsAny<GetLocationByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(location);
            var controller = new LocationsController(_mockMapper.Object, _mockMediator.Object);
            //Act
            var result = await controller.GetById(10000);
            var notFound = result as NotFoundResult;
            //Assert
            Assert.AreEqual((int)HttpStatusCode.NotFound, notFound.StatusCode);
        }
        [TestMethod]
        public async Task Create_Location_CreateLocationCommandIsCalled()
        {
            var Location = new LocationPutPostDto()
            {
                CityId = 3,
                Name = "LocationName",
                Address = "LocationAddress",
                Latitude = "1",
                Longitude = "1"

            };
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<CreateLocationCommand>(), It.IsAny<CancellationToken>())).Verifiable();

            var controller = new LocationsController(_mockMapper.Object, _mockMediator.Object);
            // Act
            await controller.CreateLocation(Location);
            // Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<CreateLocationCommand>(), It.IsAny<CancellationToken>()), Times.Once());
        }


        [TestMethod]
        public async Task Create_Location_CreateLocationReturnsOKStatusCode()
        {
            //Arrange
            var location = new Location(3, "LocationName", "LocationAddress", "1", "1");


            _mockMediator.Setup(m => m.Send(It.IsAny<CreateLocationCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(location);
            var controller = new LocationsController(_mockMapper.Object, _mockMediator.Object);
            //Act
            var result = await controller.CreateLocation(new LocationPutPostDto
            {
                CityId = 3,
                Name = "LocationName",
                Address = "LocationAddress",
                Latitude = "1",
                Longitude = "1"

            });
            var okResult = result as OkObjectResult;
            //Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult!.StatusCode);
        }

        [TestMethod]
        public async Task Update_Location_UpdateLocationCommandIsCalled()
        {
            //Arrange
            var updatedLocation = new LocationPutPostDto()
            {
                CityId = 3,
                Name = "LocationName",
                Address = "LocationAddress",
                Latitude = "1",
                Longitude = "1"

            };
            _mockMediator.Setup(m => m.Send(It.IsAny<UpdateLocationCommand>(), It.IsAny<CancellationToken>())).Verifiable();
            var controller = new LocationsController(_mockMapper.Object, _mockMediator.Object);
            //Act
            var result = await controller.UpdateLocation(1, updatedLocation);
            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<UpdateLocationCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        public async Task Update_Location_UpdateLocationReturnsNotFoundStatusCode()
        {
            //Arrange
            var location = new Location(3, "LocationName", "LocationAddress", "1", "1");


            _mockMediator.Setup(m => m.Send(It.IsAny<UpdateLocationCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(location);
            var controller = new LocationsController(_mockMapper.Object, _mockMediator.Object);
            //Act
            var result = await controller.UpdateLocation(56789, new LocationPutPostDto
            {
                CityId = 3,
                Name = "LocationName",
                Address = "LocationAddress",
                Latitude = "1",
                Longitude = "1"

            });
            var notFoundResult = result as NotFoundResult;
            //Assert
            Assert.AreEqual((int)HttpStatusCode.NotFound, notFoundResult.StatusCode);
        }
        [TestMethod]
        public async Task Delete_Location_DeleteLocationCommandIsCalled()
        {
            //Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<DeleteLocationCommand>(), It.IsAny<CancellationToken>())).Verifiable();
            //Act
            var controller = new LocationsController(_mockMapper.Object, _mockMediator.Object);
            var result = await controller.DeleteLocation(1);
            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<DeleteLocationCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        public async Task Delete_Location_DeleteLocationReturnsStatusCodeNoContent()
        {
            //Arrange
            const int id = 1;
            _mockMediator.Setup(m => m.Send(It.IsAny<DeleteLocationCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(id);
            var controller = new LocationsController(_mockMapper.Object, _mockMediator.Object);
            //Act
            var result = await controller.DeleteLocation(id);
            var noContent = result as NoContentResult;
            //Assert 
            Assert.AreEqual((int)HttpStatusCode.NoContent, noContent!.StatusCode);
        }

    }
}
