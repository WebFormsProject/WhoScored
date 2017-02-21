using Moq;
using NUnit.Framework;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.LeagueTableServiceTests
{
    [TestFixture]
    public class GetLeagueTableById_Should
    {
        [Test]
        public void ReturnCorrectLeagueTable_WhenPassedIdIsValid()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<LeagueTable>>();

            LeagueTable leagueTable = new LeagueTable();
            repositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(leagueTable);

            ILeagueTableService leagueTableService = new LeagueTableService(repositoryMock.Object);
            LeagueTable actualLeagueTable = leagueTableService.GetLeagueTableById(It.IsAny<int>());

            Assert.AreSame(leagueTable, actualLeagueTable);
        }

        [Test]
        public void ReturnNull_WhenPassedIdIsInvalid()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<LeagueTable>>();
            ILeagueTableService leagueTableService = new LeagueTableService(repositoryMock.Object);

            int invalidLeagueTableId = 33;
            LeagueTable resultLeagueTable = leagueTableService.GetLeagueTableById(invalidLeagueTableId);

            Assert.IsNull(resultLeagueTable);
        }

        [Test]
        public void CallRepositoryMethodOnce_WhenPassedIdIsValid()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<LeagueTable>>();
            ILeagueTableService leagueTableService = new LeagueTableService(repositoryMock.Object);

            leagueTableService.GetLeagueTableById(It.IsAny<int>());

            repositoryMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }
    }
}
