using ClaimSubmissionApi.Data.Dtos;
using ClaimSubmissionApi.Model;
using ClaimSubmissionApi.Repository.Interfaces;
using ClaimSubmissionApi.Services;
using Moq;


namespace ClaimSubmissionApi.Test.Test.Repository
{
    [TestFixture]
    public class ClaimRepositoryTest
    {
        [Test]
        public async Task GetClaims()
        {
            // Arrange
            var claimRepositoryMock = new Mock<IClaimRepository>();
            var expectedClaim = new Claim(); // Mocked claim object

            // Set up the mock behavior
            claimRepositoryMock
                .Setup(repository => repository.GetClaim(It.IsAny<long>()))
                .Returns(Task.FromResult(expectedClaim));

            var claimsService = new ClaimsServices(claimRepositoryMock.Object);

            // Act
            var result = await claimsService.GetClaim(123);

            // Assert
            Assert.AreEqual(expectedClaim, result);
            claimRepositoryMock.Verify(repository => repository.GetClaim(123), Times.Once);
        }
        [Test]
        public async Task GetAllClaims()
        {
            // Arrange
            var claimRepositoryMock = new Mock<IClaimRepository>();
            var expectedClaim = new List<Claim>(); // Mocked claim object

            // Set up the mock behavior
            claimRepositoryMock
                .Setup(repository => repository.GetAllClaims())
                .Returns(Task.FromResult(expectedClaim));

            var claimsService = new ClaimsServices(claimRepositoryMock.Object);

            // Act
            var result = await claimsService.GetAllClaims();

            // Assert
            Assert.AreEqual(expectedClaim, result);
            claimRepositoryMock.Verify(repository => repository.GetAllClaims(), Times.Once);
        }

        [Test]
        public async Task ReviewClaim()
        {
            // Arrange
            var claimRepositoryMock = new Mock<IClaimRepository>();
            var expectedClaim = true; // Mocked claim object

            // Set up the mock behavior
            claimRepositoryMock
                .Setup(repository => repository.ReviewClaim(It.IsAny<ReviewClaimDto>()))
                .Returns(Task.FromResult(expectedClaim));

            var claimsService = new ClaimsServices(claimRepositoryMock.Object);

            // Act
            var result = await claimsService.ReviewClaim(It.IsAny<ReviewClaimDto>());

            // Assert
            Assert.AreEqual(expectedClaim, result);
            claimRepositoryMock.Verify(repository => repository.ReviewClaim(It.IsAny<ReviewClaimDto>()), Times.Once);
        }
        [Test]
        public async Task MakeAClaimTest()
        {
            // Arrange
            var claimRepositoryMock = new Mock<IClaimRepository>();
            var expectedClaim = true; // Mocked claim object

            // Set up the mock behavior
            claimRepositoryMock
                .Setup(repository => repository.MakeClaim(It.IsAny<MakeClaimDto>()))
                .Returns(Task.FromResult(expectedClaim));

            var claimsService = new ClaimsServices(claimRepositoryMock.Object);

            // Act
            var result = await claimsService.MakeAClaim(It.IsAny<MakeClaimDto>());

            // Assert
            Assert.AreEqual(expectedClaim, result);
            claimRepositoryMock.Verify(repository => repository.MakeClaim(It.IsAny<MakeClaimDto>()), Times.Once);
        }
    }
}
