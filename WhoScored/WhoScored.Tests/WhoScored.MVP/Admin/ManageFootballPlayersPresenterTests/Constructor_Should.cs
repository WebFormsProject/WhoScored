using System;
using Moq;
using NUnit.Framework;
using WhoScored.MVP.Presenters;
using WhoScored.Services.Contracts;
using WhoScored.MVP.Admin;

namespace WhoScored.Tests.WhoScored.MVP.Admin.ManageFootballPlayersPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIFootballPlayerServiceIsNull()
        {
            var viewMock = new Mock<IManageFootballPlayersView>();
            var countryService = new Mock<ICountryService>();
            var teamService = new Mock<ITeamService>();

            var exception = Assert.Throws<ArgumentNullException>(
                () => new ManageFootballPlayersPresenter(viewMock.Object, null, countryService.Object, teamService.Object));

            StringAssert.IsMatch("footballPlayerService", exception.ParamName);
        }

        [Test]
        public void ThrowArgumentNullException_WhenICountryServiceIsNull()
        {
            var viewMock = new Mock<IManageFootballPlayersView>();
            var footballPlayerService = new Mock<IFootballPlayerService>();
            var teamService = new Mock<ITeamService>();

            var exception = Assert.Throws<ArgumentNullException>(
                () => new ManageFootballPlayersPresenter(viewMock.Object, footballPlayerService.Object, null, teamService.Object));

            StringAssert.IsMatch("countryService", exception.ParamName);
        }

        [Test]
        public void ThrowArgumentNullException_WhenITeamServiceIsNull()
        {
            var viewMock = new Mock<IManageFootballPlayersView>();
            var footballPlayerService = new Mock<IFootballPlayerService>();
            var countryService = new Mock<ICountryService>();

            var exception = Assert.Throws<ArgumentNullException>(
                () => new ManageFootballPlayersPresenter(viewMock.Object, footballPlayerService.Object, countryService.Object, null));

            StringAssert.IsMatch("teamService", exception.ParamName);
        }

        [Test]
        public void CreateInstance_WhenParametersAreValid()
        {
            var viewMock = new Mock<IManageFootballPlayersView>();
            var footballServiceMock = new Mock<IFootballPlayerService>();
            var countryService = new Mock<ICountryService>();
            var teamService = new Mock<ITeamService>();

            ManageFootballPlayersPresenter presenter = new ManageFootballPlayersPresenter(
                viewMock.Object,
                footballServiceMock.Object,
                countryService.Object,
                teamService.Object);

            Assert.IsInstanceOf<ManageFootballPlayersPresenter>(presenter);
        }
    }
}
