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
        public void ReturnLeague_WhenPassedIdIsValid()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<League>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            int leagueId = 1;
            League league = new League
            {
                Name = "Premier League",
                CountryId = 2,
                LeaugeLogo = "/photos/Leagues/premier-league.png"
            };
            repositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(league);

            ILeagueService leagueService = new LeagueService(repositoryMock.Object, unitOfWorkMock.Object);
            League actualLeague = leagueService.GetLeagueById(leagueId);

            Assert.AreSame(league, actualLeague);
        }
    }
}
