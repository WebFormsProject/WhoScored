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

namespace WhoScored.Tests.WhoScored.Services.GameServiceTests
{
    [TestFixture]
    public class GetGameById_Should
    {
        [Test]
        public void ReturnNull_WhenGameWithSuchIdDoesNotExist()
        {
            var mockedRepository = new Mock<IWhoScoredRepository<Game>>();

            IGameService gameService = new GameService(mockedRepository.Object);
            Game actualGame = gameService.GetGameById(8);

            Assert.IsNull(actualGame);
        }

        [Test]
        public void ReturnCorrectGame_WhenIdIsValid()
        {
            var id = 8;
            Game game = new Game();

            var mockedRepository = new Mock<IWhoScoredRepository<Game>>();
            mockedRepository.Setup(x => x.GetById(id)).Returns(game);

            IGameService gameService = new GameService(mockedRepository.Object);
            Game actualGame = gameService.GetGameById(8);

            Assert.AreSame(game, actualGame);
        }

        [Test]
        public void CallGetByIdOnce_WhenIdIsValid()
        {
            var mockedRepository = new Mock<IWhoScoredRepository<Game>>();

            IGameService gameService = new GameService(mockedRepository.Object);
            gameService.GetGameById(8);

            mockedRepository.Verify(x => x.GetById(8), Times.Once);
        }
    }
}
