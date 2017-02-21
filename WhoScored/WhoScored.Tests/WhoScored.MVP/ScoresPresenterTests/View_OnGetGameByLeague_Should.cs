using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using WhoScored.Models.Models;
using WhoScored.MVP.Models;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.MVP.ScoresPresenterTests
{
    [TestFixture]
    public class View_OnGetGameByLeague_Should
    {
        [Test]
        public void AddGamesByLeagueToViewModel_WhenOnGetGameByLeagueEventIsRaised()
        {
            var leagueServiceMock = new Mock<ILeagueService>();
            var viewMock = new Mock<IScoresView>();
            viewMock.Setup(v => v.Model).Returns(new ScoresViewModel());

            League league = new League();
            IEnumerable<Game> gamesByLeague = new List<Game>();
            var gameServiceMock = new Mock<IGameService>();
            gameServiceMock.Setup(x => x.GetGamesByLeague(league)).Returns(gamesByLeague);

            ScoresPresenter scoresPresenter = new ScoresPresenter(viewMock.Object, gameServiceMock.Object, leagueServiceMock.Object);

            viewMock.Raise(x => x.OnGetGameByLeague += null, new GameNameEventArgs(league));

            CollectionAssert.AreEquivalent(gamesByLeague, viewMock.Object.Model.GamesByLeague);
        }
    }
}
