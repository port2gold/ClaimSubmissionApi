using ClaimSubmissionApi.Controllers;
using ClaimSubmissionApi.Data.Dtos;
using ClaimSubmissionApi.Services;
using ClaimSubmissionApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimSubmissionApi.Test.Test.ControllerTest
{
    [TestFixture]
    public class UserControllerTest
    {
        [Test]
        public async Task SignInTest_ReturnsOkResult_WithValidUser()
        {
            // Arrange
            var authServicesMock = new Mock<IAuthServices>();
            var expectedClaim = new UserPayload(); // Mocked claim object

            authServicesMock
                .Setup(service => service.SignIn(It.IsAny<SignInDto>()))
                .Returns(Task.FromResult(expectedClaim));

            var controller = new UserController(authServicesMock.Object);

            // Act
            var result = await controller.SignIn(It.IsAny<SignInDto>());

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(expectedClaim, okResult.Value);
        }

        [Test]
        public async Task SignIn_ReturnsNotFound_WhenClaimIsNull()
        {
            // Arrange
            var authServiceMock = new Mock<IAuthServices>();
            authServiceMock
                 .Setup(service => service.SignIn(It.IsAny<SignInDto>()))
                 .Returns(Task.FromResult<UserPayload>(null));

            var controller = new UserController(authServiceMock.Object);

            // Act
            var result = await controller.SignIn(It.IsAny<SignInDto>());

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public async Task RegisterUserTest_ReturnsOkResult_WithValidRequest()
        {
            // Arrange
            var authServicesMock = new Mock<IAuthServices>();
            var expectedClaim = true; // Mocked claim object

            authServicesMock
                .Setup(service => service.CreateUserAdmin(It.IsAny<CreateUserDto>()))
                .Returns(Task.FromResult(expectedClaim));

            var controller = new UserController(authServicesMock.Object);

            // Act
            var result = await controller.RegisterAdminUser(It.IsAny<CreateUserDto>());

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(expectedClaim, okResult.Value);
        }

        [Test]
        public async Task RegisterUserPolicyHolderTest_ReturnsOkResult_WithValidRequest()
        {
            // Arrange
            var authServicesMock = new Mock<IAuthServices>();
            var expectedClaim = true; // Mocked claim object

            authServicesMock
                .Setup(service => service.CreateUserPolicyHolder(It.IsAny<CreateUserDto>()))
                .Returns(Task.FromResult(expectedClaim));

            var controller = new UserController(authServicesMock.Object);

            // Act
            var result = await controller.RegisterUserPolicyHolder(It.IsAny<CreateUserDto>());

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(expectedClaim, okResult.Value);
        }


    }
}
