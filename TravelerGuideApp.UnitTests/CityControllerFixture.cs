using System.Net;
using System.Runtime.CompilerServices;
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
    public class CityControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new();
        private readonly Mock<IMapper> _mockMapper = new();

        [TestMethod]
        public async Task Get_All_Cities_GetCitiesListQueryIsCalled()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<GetCitiesListQuery>(), It.IsAny<CancellationToken>())).Verifiable();
            var controller = new CitiesController(_mockMapper.Object, _mockMediator.Object);

            // Act
            await controller.GetAll();

            // Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetCitiesListQuery>(), It.IsAny<CancellationToken>()), Times.Once());

        }
        [TestMethod]
        public async Task Get_City_By_Id_GetCityByIdQueryIsCalled()
        {
            // Arrange
            var controller = new CitiesController(_mockMapper.Object, _mockMediator.Object);
            _mockMediator.Setup(m => m.Send(It.IsAny<GetCityByIdQuery>(), It.IsAny<CancellationToken>())).Verifiable();
            // Act
            await controller.GetById(1);
            // Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetCityByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Get_City_By_Id_GetCityByIdReturnsStatusCodeNotFound()
        {
            //Arrange
            var city = new City("CityName", "CityCountry");
            _mockMediator.Setup(m => m.Send(It.IsAny<GetCityByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(city);
            var controller = new CitiesController(_mockMapper.Object, _mockMediator.Object);
            //Act
            var result = await controller.GetById(100000);
            var notFoundResult = result as NotFoundResult;
            //Assert
            Assert.AreEqual((int)HttpStatusCode.NotFound, notFoundResult.StatusCode);
        }

        [TestMethod]
        public async Task Create_City_CreateCityCommandIsCalled()
        {
            var cityDto = new CityPutPostDto
            {
                Name = "CityName",
                Country = "CityCountry"
            };
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<CreateCityCommand>(), It.IsAny<CancellationToken>())).Verifiable();

            var controller = new CitiesController(_mockMapper.Object, _mockMediator.Object);
            // Act
            await controller.CreateCity(cityDto);
            // Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<CreateCityCommand>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Create_City_CreateCityReturnsOKStatusCode()
        {
            //Arrange
            var city = new City("CityName", "CityCountry");
            _mockMediator.Setup(m => m.Send(It.IsAny<CreateCityCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(city);
            var controller = new CitiesController(_mockMapper.Object, _mockMediator.Object);
            //Act
            var result = await controller.CreateCity(new CityPutPostDto
            { Name = "CityName", Country = "CityCountry" });
            var okResult = result as OkObjectResult;
            //Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult!.StatusCode);
        }

        [TestMethod]
        public async Task Update_City_UpdateCityCommandIsCalled()
        {
            //Arrange
            var updatedCity = new CityPutPostDto
            {
                Name = "UpdatedName",
                Country = "UpdatedCountry"
            };
            _mockMediator.Setup(m => m.Send(It.IsAny<UpdateCityCommand>(), It.IsAny<CancellationToken>())).Verifiable();
            var controller = new CitiesController(_mockMapper.Object, _mockMediator.Object);
            //Act
            var result = await controller.UpdateCity(1, updatedCity);
            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<UpdateCityCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }


        [TestMethod]
        public async Task Update_City_UpdateCityReturnsNotFoundStatusCode()
        {

            //Arrange 
            var updatedCity = new City("UpdatedName", "UpdatedCountry");
            _mockMediator.Setup(m => m.Send(It.IsAny<UpdateCityCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(updatedCity);
            var controller = new CitiesController(_mockMapper.Object, _mockMediator.Object);
            //Act 
            var result = await controller.UpdateCity(10000, new CityPutPostDto { Name = "UpdatedName", Country = "UpdatedCountry" });
            var notFoundResult = result as NotFoundResult;
            //Assert
            Assert.AreEqual((int)HttpStatusCode.NotFound, notFoundResult.StatusCode);
        }

        [TestMethod]
        public async Task Delete_City_DeleteCityCommandIsCalled()
        {
            //Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<DeleteCityCommand>(), It.IsAny<CancellationToken>())).Verifiable();
            //Act
            var controller = new CitiesController(_mockMapper.Object, _mockMediator.Object);
            var result = await controller.DeleteCity(1);
            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<DeleteCityCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        public async Task Delete_City_DeleteCityReturnsStatusCodeNoContent()
        {
            //Arrange
            const int id = 1;
            _mockMediator.Setup(m => m.Send(It.IsAny<DeleteCityCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(id);
            var controller = new CitiesController(_mockMapper.Object, _mockMediator.Object);
            //Act
            var result = await controller.DeleteCity(id);
            var noContent = result as NoContentResult;
            //Assert 
            Assert.AreEqual((int)HttpStatusCode.NoContent, noContent.StatusCode);
        }
    }
}