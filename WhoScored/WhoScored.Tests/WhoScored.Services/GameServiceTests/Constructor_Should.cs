using System;
using Moq;
using NUnit.Framework;
using WhoScored.Data;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.GameServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIRepositoryArgumentIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(()=> new GameService(null));
            StringAssert.IsMatch("gameRepository", exception.ParamName);
        }

        [Test]
        public void ReturnCorrectInstance_WhenArgumentsAreValid()
        {
            var mockedRepository = new Mock<IWhoScoredRepository<Game>>();

            IGameService gameService = new GameService(mockedRepository.Object);
            Assert.IsInstanceOf<GameService>(gameService);
        }
    }
}
