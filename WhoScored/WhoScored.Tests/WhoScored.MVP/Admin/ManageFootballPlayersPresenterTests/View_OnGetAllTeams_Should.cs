using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using WhoScored.Models.Models;
using WhoScored.MVP.Admin;
using WhoScored.MVP.Presenters;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.MVP.Admin.ManageFootballPlayersPresenterTests
{
    [TestFixture]
    public class View_OnGetAllTeams_Should
    {
        [Test]
        public void AddAllPlayersToViewModel_WhenOnGetAllFootballPlayersEventIsRaised()
        {
            var footballPlayerServiceMock = new Mock<IFootballPlayerService>();
            var countryServiceMock = new Mock<ICountryService>();
            var teamServiceMock = new Mock<ITeamService>();
            var viewMock = new Mock<IManageFootballPlayersView>();
            viewMock.Setup(v => v.Model).Returns(new ManageFootballPlayersViewModel());

            IEnumerable<Team> teams = new List<Team>();
            teamServiceMock.Setup(x => x.GetAllTeams()).Returns(teams);

            ManageFootballPlayersPresenter scoresPresenter = new ManageFootballPlayersPresenter(
                viewMock.Object,
                footballPlayerServiceMock.Object,
                countryServiceMock.Object,
                teamServiceMock.Object);

            viewMock.Raise(x => x.OnGetAllTeams += null, EventArgs.Empty);

            CollectionAssert.AreEquivalent(teams, viewMock.Object.Model.Teams);
        }
    }
}
