using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.LeaguesServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void GetAllLeagues()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<League>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            ILeagueService leagueService = new LeagueService(repositoryMock.Object, unitOfWorkMock.Object);

            IList<League> leagues = new List<League>()
            {
                new League() { Name = "Premier League", CountryId = 2, LeaugeLogo = "/photos/Leagues/premier-league.png" },
                new League() { Name = "La Liga", CountryId = 1, LeaugeLogo = "/photos/Leagues/la-liga.png" }
            };

            repositoryMock.Setup(x => x.GetAll()).Returns(leagues);
            var actualLeagues = leagueService.GetAlLeagues();

            CollectionAssert.AreEquivalent(leagues, actualLeagues);
        }

        [Test]
        public void CallRepositoryMethodOnce()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<League>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            ILeagueService leagueService = new LeagueService(repositoryMock.Object, unitOfWorkMock.Object);

            leagueService.GetAlLeagues();

            repositoryMock.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
