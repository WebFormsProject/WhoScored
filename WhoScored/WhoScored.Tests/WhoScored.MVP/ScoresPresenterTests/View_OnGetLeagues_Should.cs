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
    public class View_OnGetLeagues_Should
    {
        [Test]
        public void AddAllLeaguesToViewModel_WhenOnGetLeaguesEventIsRaised()
        {
            var gameServiceMock = new Mock<IGameService>();
            var viewMock = new Mock<IScoresView>();
            viewMock.Setup(v => v.Model).Returns(new ScoresViewModel());

            IEnumerable<League> leagues = new List<League>();
            var leagueServiceMock = new Mock<ILeagueService>();
            leagueServiceMock.Setup(x => x.GetAlLeagues()).Returns(leagues);

            ScoresPresenter scoresPresenter = new ScoresPresenter(viewMock.Object, gameServiceMock.Object, leagueServiceMock.Object);

            viewMock.Raise(x => x.OnGetLeagues += null, new GameNameEventArgs(new League()));

            CollectionAssert.AreEquivalent(leagues, viewMock.Object.Model.Leagues);
        }
    }
}
