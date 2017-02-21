using Moq;
using NUnit.Framework;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.LeaguesServiceTests
{
    [TestFixture]
    public class GetLeagueById_Should
    {
        [Test]
        public void ReturnCorrectLeague_WhenPassedIdIsValid()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<League>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            League league = new League();
            repositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(league);

            ILeagueService leagueService = new LeagueService(repositoryMock.Object, unitOfWorkMock.Object);
            League actualLeague = leagueService.GetLeagueById(It.IsAny<int>());

            Assert.AreSame(league, actualLeague);
        }

        [Test]
        public void ReturnNull_WhenPassedIdIsInvalid()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<League>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            ILeagueService leagueService = new LeagueService(repositoryMock.Object, unitOfWorkMock.Object);

            int invalidLeagueId = 33;
            League resultLeague = leagueService.GetLeagueById(invalidLeagueId);

            Assert.IsNull(resultLeague);
        }

        [Test]
        public void CallRepositoryMethodOnce_WhenPassedIdIsValid()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<League>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            ILeagueService leagueService = new LeagueService(repositoryMock.Object, unitOfWorkMock.Object);

            leagueService.GetLeagueById(It.IsAny<int>());

            repositoryMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }
    }
}
