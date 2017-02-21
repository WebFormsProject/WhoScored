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
    public class View_OnGetAllPlayers_Should
    {
        [Test]
        public void AddAllPlayersToViewModel_WhenOnGetAllFootballPlayersEventIsRaised()
        {
            var footballPlayerServiceMock = new Mock<IFootballPlayerService>();
            var countryServiceMock = new Mock<ICountryService>();
            var teamServiceMock = new Mock<ITeamService>();
            var viewMock = new Mock<IManageFootballPlayersView>();
            viewMock.Setup(v => v.Model).Returns(new ManageFootballPlayersViewModel());

            IEnumerable<FootballPlayer> footballPlayers = new List<FootballPlayer>();
            footballPlayerServiceMock.Setup(x => x.GetAllFootballPlayers()).Returns(footballPlayers);

            ManageFootballPlayersPresenter scoresPresenter = new ManageFootballPlayersPresenter(
                viewMock.Object,
                footballPlayerServiceMock.Object,
                countryServiceMock.Object,
                teamServiceMock.Object);

            viewMock.Raise(x => x.OnGetAllPlayers += null, EventArgs.Empty);

            CollectionAssert.AreEquivalent(footballPlayers, viewMock.Object.Model.FootballPlayers);
        }
    }
}
