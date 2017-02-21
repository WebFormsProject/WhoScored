using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.FootballPlayerServiceTests
{
    [TestFixture]
    public class GetAllFootballPlayers_Should
    {
        [Test]
        public void GetAllFootballPlayers()
        {
            var mockedRepository = new Mock<IWhoScoredRepository<FootballPlayer>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            IEnumerable<FootballPlayer> players = new List<FootballPlayer>() { new FootballPlayer() };
            mockedRepository.Setup(x => x.GetAll()).Returns(players);

            IFootballPlayerService footballPlayerService = new FootballPlayerService(mockedRepository.Object, mockedUnitOfWork.Object);
            var actualPlayes = footballPlayerService.GetAllFootballPlayers();

            CollectionAssert.AreEquivalent(players, actualPlayes);
        }

        [Test]
        public void CallRepositoryMethodOnce()
        {
            var mockedRepository = new Mock<IWhoScoredRepository<FootballPlayer>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            IFootballPlayerService footballPlayerService = new FootballPlayerService(mockedRepository.Object, mockedUnitOfWork.Object);
            footballPlayerService.GetAllFootballPlayers();

            mockedRepository.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
