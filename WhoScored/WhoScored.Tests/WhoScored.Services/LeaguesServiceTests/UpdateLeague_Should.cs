using Moq;
using NUnit.Framework;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.LeaguesServiceTests
{
    [TestFixture]
    public class UpdateLeague_Should
    {
        [Test]
        public void CallRepositoryMethodOnce_WhenDataIsValid()
        {
            var leagueMock = new Mock<League>();
            var repositoryMock = new Mock<IWhoScoredRepository<League>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            ILeagueService leagueService = new LeagueService(repositoryMock.Object, unitOfWorkMock.Object);

            leagueService.UpdateLeague(leagueMock.Object);

            repositoryMock.Verify(x => x.Update(It.IsAny<League>()), Times.Once);
        }

        [Test]
        public void CallUnitOfWorkCommitMethodOnce()
        {
            var leagueMock = new Mock<League>();
            var repositoryMock = new Mock<IWhoScoredRepository<League>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            ILeagueService leagueService = new LeagueService(repositoryMock.Object, unitOfWorkMock.Object);

            leagueService.UpdateLeague(leagueMock.Object);

            unitOfWorkMock.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void CallUnitOfWorkDisposeMethodOnce()
        {
            var leagueMock = new Mock<League>();
            var repositoryMock = new Mock<IWhoScoredRepository<League>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            ILeagueService leagueService = new LeagueService(repositoryMock.Object, unitOfWorkMock.Object);

            unitOfWorkMock.Setup(x => x.Dispose()).Verifiable();
            leagueService.UpdateLeague(leagueMock.Object);

            unitOfWorkMock.Verify(x => x.Dispose(), Times.Once);
        }
    }
}
