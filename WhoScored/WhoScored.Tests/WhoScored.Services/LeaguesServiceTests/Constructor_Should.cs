using Moq;
using NUnit.Framework;
using System;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.LeaguesServiceTests
{
    [TestFixture]
    class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedRepositoryIsNull()
        {
            var unitOfworkMock = new Mock<IUnitOfWork>();

            var actualMessage = Assert.Throws<ArgumentNullException>(() => new LeagueService(null, unitOfworkMock.Object));

            StringAssert.IsMatch("leagueRepository", actualMessage.ParamName);
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedUnitOfWorkIsNull()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<League>>();

            var actualMessage = Assert.Throws<ArgumentNullException>(() => new LeagueService(repositoryMock.Object, null));

            StringAssert.IsMatch("unitOfWork", actualMessage.ParamName);
        }

        [Test]
        public void CreateCorrectInstanceOfLeagueService_WhenPassedArgumentsAreValid()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<League>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            ILeagueService leagueService = new LeagueService(repositoryMock.Object, unitOfWorkMock.Object);

            Assert.IsInstanceOf(typeof(LeagueService), leagueService);
        }
    }
}
