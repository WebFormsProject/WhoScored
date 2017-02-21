using Moq;
using NUnit.Framework;
using WhoScored.Models.Models;
using WhoScored.MVP.Admin;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Presenters;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.MVP.Admin.ManageFootballPlayersPresenterTests
{
    [TestFixture]
    public class View_OnDeleteFootballPlayer_Should
    {
        [Test]
        public void CallDeleteMethodOnce_WhenFootballPlayerIsFound()
        {
            var viewMock = new Mock<IManageFootballPlayersView>();
            var footballPlayerServiceMock = new Mock<IFootballPlayerService>();
            var countryServiceMock = new Mock<ICountryService>();
            var teamServiceMock = new Mock<ITeamService>();

            footballPlayerServiceMock.Setup(x => x.GetFootballPlayerById(It.IsAny<int>())).Returns(new FootballPlayer());

            ManageFootballPlayersPresenter presenter = new ManageFootballPlayersPresenter(
                           viewMock.Object,
                           footballPlayerServiceMock.Object,
                           countryServiceMock.Object,
                           teamServiceMock.Object);

            viewMock.Raise(x => x.OnDeleteFootballPlayer += null, new IdEventArgs(It.IsAny<int>()));

            footballPlayerServiceMock.Verify(x => x.DeleteFootballPlayer(It.IsAny<FootballPlayer>()), Times.Once);
        }

        [Test]
        public void NotCallDeleteFootballPlayer_WhenItemIsNotFound()
        {
            var viewMock = new Mock<IManageFootballPlayersView>();
            var footballPlayerServiceMock = new Mock<IFootballPlayerService>();
            var countryServiceMock = new Mock<ICountryService>();
            var teamServiceMock = new Mock<ITeamService>();

            ManageFootballPlayersPresenter presenter = new ManageFootballPlayersPresenter(
                           viewMock.Object,
                           footballPlayerServiceMock.Object,
                           countryServiceMock.Object,
                           teamServiceMock.Object);

            footballPlayerServiceMock.Verify(x => x.DeleteFootballPlayer(It.IsAny<FootballPlayer>()), Times.Never);
        }
    }
}
