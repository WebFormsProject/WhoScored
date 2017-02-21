using Moq;
using NUnit.Framework;
using System;
using WhoScored.MVP.Models;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.MVP.ScoresPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenGameServiceIsNull()
        {
            var leagueService = new Mock<ILeagueService>();
            var viewMock = new Mock<IScoresView>();
            viewMock.Setup(v => v.Model).Returns(new ScoresViewModel());

            var actualMessage = Assert.Throws<ArgumentNullException>(
                () => new ScoresPresenter(viewMock.Object, null, leagueService.Object));

            StringAssert.IsMatch("gameService", actualMessage.ParamName);
        }

        [Test]
        public void ThrowArgumentNullException_WhenLeagueServiceIsNull()
        {
            var gameService = new Mock<IGameService>();
            var viewMock = new Mock<IScoresView>();
            viewMock.Setup(v => v.Model).Returns(new ScoresViewModel());

            var actualMessage = Assert.Throws<ArgumentNullException>(
                () => new ScoresPresenter(viewMock.Object, gameService.Object, null));

            StringAssert.IsMatch("leagueService", actualMessage.ParamName);
        }

        [Test]
        public void CreateCorrectInstanceOfScorePresenter_WhenPassedArgumentsAreValid()
        {
            var gameService = new Mock<IGameService>();
            var leagueService = new Mock<ILeagueService>();
            var viewMock = new Mock<IScoresView>();
            viewMock.Setup(v => v.Model).Returns(new ScoresViewModel());

            ScoresPresenter scoresPresenter = new ScoresPresenter(viewMock.Object, gameService.Object, leagueService.Object);

            Assert.IsInstanceOf<ScoresPresenter>(scoresPresenter);
        }
    }
}
