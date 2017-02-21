using Moq;
using NUnit.Framework;
using WhoScored.Models.Models;
using WhoScored.MVP.Models;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.MVP.TeamPresenterTests
{
    [TestFixture]
    public class View_OnOnGetTeam_Should
    {
        [Test]
        public void AddTeamToViewModel_WhenOnGetTeamEventIsRaised()
        {
            var viewMock = new Mock<ITeamView>();
            viewMock.Setup(v => v.Model).Returns(new TeamViewModel());

            Team team = new Team();
            var teamServiceMock = new Mock<ITeamService>();
            teamServiceMock.Setup(x => x.GetTeamById(It.IsAny<int>())).Returns(team);

            TeamPresenter teamPresenter = new TeamPresenter(viewMock.Object, teamServiceMock.Object);

            viewMock.Raise(x => x.OnGetTeam += null, new IdEventArgs(It.IsAny<int>()));

            Assert.AreEqual(team, viewMock.Object.Model.Team);
        }
    }
}
