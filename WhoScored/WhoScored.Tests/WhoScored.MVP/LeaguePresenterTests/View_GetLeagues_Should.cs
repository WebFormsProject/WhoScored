using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using WhoScored.Models.Models;
using WhoScored.MVP.Models;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.MVP.LeaguePresenterTests
{
    [TestFixture]
    public class View_GetLeagues_Should
    {

        [Test]
        public void SetLeagueTablesToViewModel_WhenOnGetLeaguesIsRaised()
        {
            var viewMock = new Mock<ILeaguesView>();
            var leagueServiceMock = new Mock<ILeagueService>();

            IEnumerable<League> leagues = new List<League>() { new League() };
            leagueServiceMock.Setup(x => x.GetAlLeagues()).Returns(leagues);

            LeaguesViewModel model = new LeaguesViewModel();
            viewMock.Setup(x => x.Model).Returns(model);

            LeaguePresenter presenter = new LeaguePresenter(viewMock.Object, leagueServiceMock.Object);


            viewMock.Raise(x => x.OnGetLeagues += null, new IdEventArgs(8));

            Assert.AreEqual(leagues, viewMock.Object.Model.Leagues);
        }
    }
}
