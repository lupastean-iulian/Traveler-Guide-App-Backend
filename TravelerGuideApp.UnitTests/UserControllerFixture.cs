

using System.Net;
using System.Security.Cryptography.X509Certificates;
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
    public class UserControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new();
        private readonly Mock<IMapper> _mockMapper = new();

        [TestMethod]
        public async Task Get_All_Users_GetUserListQueryIsCalled()
        {
            //    // Arrange
            //    _mockMediator.Setup(m => m.Send(It.IsAny<GetUsersQuery>(), It.IsAny<CancellationToken>())).Verifiable();
            //    // Act
            //    var controller = new UserController(_mockMapper.Object, _mockMediator.Object);
            //    await controller.GetAll();
            //    // Assert
            //    _mockMediator.Verify(x => x.Send(It.IsAny<GetUsersQuery>(), It.IsAny<CancellationToken>()), Times.Once());

            //}
            //[TestMethod]
            //public async Task Get_User_By_Id_GetUserByIdQueryIsCalled()
            //{
            //    // Arrange
            //    _mockMediator.Setup(m => m.Send(It.IsAny<GetUserByIdQuery>(), It.IsAny<CancellationToken>())).Verifiable();
            //    // Act
            //    var controller = new UserController(_mockMapper.Object, _mockMediator.Object);
            //    await controller.GetById(1);
            //    // Assert
            //    _mockMediator.Verify(x => x.Send(It.IsAny<GetUserByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());
            //}
            //[TestMethod]
            //public async Task Get_User_By_Id_GetUserByIdReturnsNotFound()
            //{
            //    //Arrange

            //    var user = new User("Ion", "Popescu", "Ionpopescu@yahoo.com", "passsshhahahs", "Visitor");
            //    _mockMediator.Setup(m => m.Send(It.IsAny<GetUserByIdQuery>(), It.IsAny<CancellationToken>()))
            //        .ReturnsAsync(user);
            //    var controller = new UserController(_mockMapper.Object, _mockMediator.Object);
            //    //Act
            //    var result = await controller.GetById(10000);
            //    var notFound = result as NotFoundResult;
            //    //Assert
            //    Assert.AreEqual((int)HttpStatusCode.NotFound, notFound.StatusCode);
            //}

            //[TestMethod]
            //public async Task Create_User_CreateUserCommandIsCalled()
            //{

            //    // Arrange
            //    var user = new User("Ion", "Popescu", "Ionpopescu@yahoo.com", "passsshhahahs", "Visitor");

            //    _mockMediator.Setup(m => m.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(user);

            //    var controller = new UserController(_mockMapper.Object, _mockMediator.Object);
            //    // Act
            //    var result = await controller.CreateUser(new UserPutPostDto
            //    {
            //        FirstName = "Ion",
            //        LastName = "Popescu",
            //        Email = "Ionpopescu@yahoo.com",
            //        Password = "0assssssshahsa",
            //        UserType = "Visitor"

            //    });
            //    var okResult = result as OkObjectResult;
            //    // Assert
            //    Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
        }


    }
}
