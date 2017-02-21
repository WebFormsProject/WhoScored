using Moq;
using NUnit.Framework;
using WhoScored.Models.Models;
using WhoScored.MVP.Models;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.MVP.ScoresPresenterTests
{
    [TestFixture]
    public class View_OnGetGameById_Should
    {
        [Test]
        public void AddGameToViewModel_WhenOnGetGameByIdEventIsRaised()
        {
            var leagueServiceMock = new Mock<ILeagueService>();
            var viewMock = new Mock<IScoresView>();
            viewMock.Setup(v => v.Model).Returns(new ScoresViewModel());

            Game game = new Game();
            int gameId = 1;
            var gameServiceMock = new Mock<IGameService>();
            gameServiceMock.Setup(x => x.GetGameById(gameId)).Returns(game);

            ScoresPresenter scoresPresenter = new ScoresPresenter(viewMock.Object, gameServiceMock.Object, leagueServiceMock.Object);

            viewMock.Raise(x => x.OnGetGameById += null, new IdEventArgs(gameId));

            Assert.AreEqual(game, viewMock.Object.Model.Game);
        }
    }
}
