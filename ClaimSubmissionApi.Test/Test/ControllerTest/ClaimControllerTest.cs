using ClaimSubmissionApi.Controllers;
using ClaimSubmissionApi.Data.Dtos;
using ClaimSubmissionApi.Model;
using ClaimSubmissionApi.Services;
using ClaimSubmissionApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using System.Security.Principal;

namespace ClaimSubmissionApi.Test.Test.ControllerTest
{
    [TestFixture]
    public class ClaimControllerTest
    {
        [Test]
        public async Task GetClaim_ReturnsOkResult_WithClaim()
        {
            // Arrange
            var claimServiceMock = new Mock<IClaimsServices>();
            var expectedClaim = new Claim(); // Mocked claim object

            claimServiceMock
                .Setup(service => service.GetClaim(It.IsAny<long>()))
                .Returns(Task.FromResult(expectedClaim));

            var controller = new ClaimsController(claimServiceMock.Object);

            // Act
            var result = await controller.GetClaim(123);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(expectedClaim, okResult.Value);
        }

        [Test]
        public async Task GetClaim_ReturnsNotFound_WhenClaimIsNull()
        {
            // Arrange
            var claimServiceMock = new Mock<IClaimsServices>();
            claimServiceMock
                .Setup(service => service.GetClaim(It.IsAny<long>()))
                .Returns(Task.FromResult<Claim>(null));

            var controller = new ClaimsController(claimServiceMock.Object);

            // Act
            var result = await controller.GetClaim(456);

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }

        [Test]
        public async Task GetAllClaim_ReturnsOkResult_WithClaim()
        {
            // Arrange
            var claimServiceMock = new Mock<IClaimsServices>();
            var expectedClaim = new List<Claim>(); // Mocked claim object

            claimServiceMock
                .Setup(service => service.GetAllClaims())
                .Returns(Task.FromResult(expectedClaim));

            var controller = new ClaimsController(claimServiceMock.Object);

            // Act
            var result = await controller.GetAllClaims();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(expectedClaim, okResult.Value);
        }

        [Test]
        public async Task GetAllClaim_ReturnsNotFound_WhenClaimIsNull()
        {
            // Arrange
            var claimServiceMock = new Mock<IClaimsServices>();
            claimServiceMock
                .Setup(service => service.GetAllClaims())
                .Returns(Task.FromResult<List<Claim>>(null));

            var controller = new ClaimsController(claimServiceMock.Object);

            // Act
            var result = await controller.GetAllClaims();

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }

        [Test]
        public async Task ReviewClaim_ReturnsOkResult_WithValidRequest()
        {
            // Arrange
            var claimServiceMock = new Mock<IClaimsServices>();
            var expectedClaim = true; // Mocked claim object

            claimServiceMock
                .Setup(service => service.ReviewClaim(It.IsAny<ReviewClaimDto>()))
                .Returns(Task.FromResult(expectedClaim));

            var controller = new ClaimsController(claimServiceMock.Object);

            // Act
            var result = await controller.ReviewClaim(It.IsAny<ReviewClaimDto>());

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
      
        }

        [Test]
        public async Task ReviewClaim_ReturnsNotFound_WhenClaimIsNull()
        {
            // Arrange
            var claimServiceMock = new Mock<IClaimsServices>();
            claimServiceMock
                .Setup(service => service.ReviewClaim(It.IsAny<ReviewClaimDto>()))
                .Returns(Task.FromResult<bool>(false));

            var controller = new ClaimsController(claimServiceMock.Object);

            // Act
            var result = await controller.ReviewClaim(It.IsAny<ReviewClaimDto>());

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public async Task MakeClaim_ReturnsOkResult_WithClaim()
        {
            // Arrange
            var claimServiceMock = new Mock<IClaimsServices>();
            var identityMock = new Mock<IIdentity>();
            var expectedClaim = true; // Mocked claim object

            claimServiceMock
                .Setup(service => service.MakeAClaim(It.IsAny<MakeClaimDto>()))
                .Returns(Task.FromResult(expectedClaim));


            var controller = new ClaimsController(claimServiceMock.Object);

            // Act
            var result = await controller.MakeAClaim(It.IsAny<MakeClaimDto>());

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(expectedClaim, okResult.Value);
        }

        [Test]
        public async Task MakeClaim_ReturnsNotFound_WhenClaimIsNull()
        {
            // Arrange
            var claimServiceMock = new Mock<IClaimsServices>();
            claimServiceMock
                .Setup(service => service.MakeAClaim(It.IsAny<MakeClaimDto>()))
                .Returns(Task.FromResult<bool>(false));

            var controller = new ClaimsController(claimServiceMock.Object);

            // Act
            var result = await controller.MakeAClaim(It.IsAny<MakeClaimDto>());

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }
    }
}
