using System;
using System.Collections;
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

namespace WhoScored.Tests.WhoScored.Services.GameServiceTests
{
    [TestFixture]
    public class GetGamesByLeague_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedLeagueParameterIsNull()
        {
            var mockedRepository = new Mock<IWhoScoredRepository<Game>>();

            IGameService gameService = new GameService(mockedRepository.Object);

            var exception = Assert.Throws<ArgumentNullException>(() => gameService.GetGamesByLeague(null));
            StringAssert.IsMatch("league", exception.ParamName);
        }

        [Test]
        public void ReturnCorrectCountOfGames_WhenPassedParameterIsValid()
        {
            var mockedRepository = new Mock<IWhoScoredRepository<Game>>();
            var mockedLeague = new Mock<League>();

            IEnumerable<Game> games = new List<Game>()
            {
                new Game() { League = mockedLeague.Object },
                new Game() { League = mockedLeague.Object },
                new Game()
            };

            mockedRepository.Setup(x => x.GetAll()).Returns(games);

            IGameService gameService = new GameService(mockedRepository.Object);
            IEnumerable<Game> actualGames = gameService.GetGamesByLeague(mockedLeague.Object);

            Assert.AreEqual(2, actualGames.Count());
        }

        [Test]
        public void ReturnEmptyCollcetion_WhenNoGamesWithPassedLeague()
        {
            var mockedRepository = new Mock<IWhoScoredRepository<Game>>();
            var mockedLeague = new Mock<League>();

            IGameService gameService = new GameService(mockedRepository.Object);

            IEnumerable<Game> games = new List<Game>()
            {
                new Game(),
                new Game()
            };

            mockedRepository.Setup(x => x.GetAll()).Returns(games);
            IEnumerable<Game> actualGames = gameService.GetGamesByLeague(mockedLeague.Object);

            Assert.IsEmpty(actualGames);
        }

        [Test]
        public void CallGetAllOnce_WhenArgumentsValid()
        {
            var mockedRepository = new Mock<IWhoScoredRepository<Game>>();
            var mockedLeague = new Mock<League>();

            IGameService gameService = new GameService(mockedRepository.Object);

            IEnumerable<Game> games = new List<Game>()
            {
                new Game(),
                new Game()
            };

            mockedRepository.Setup(x => x.GetAll()).Returns(games);
            gameService.GetGamesByLeague(mockedLeague.Object);

            mockedRepository.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
