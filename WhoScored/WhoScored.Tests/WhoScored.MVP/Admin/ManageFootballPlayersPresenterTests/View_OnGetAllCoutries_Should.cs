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
    public class View_OnGetAllCoutries_Should
    {
        [Test]
        public void AddAllCountriesToViewModel_WhenOnGetAllCountriesEventIsRaised()
        {
            var footballPlayerServiceMock = new Mock<IFootballPlayerService>();
            var countryServiceMock = new Mock<ICountryService>();
            var teamServiceMock = new Mock<ITeamService>();
            var viewMock = new Mock<IManageFootballPlayersView>();
            viewMock.Setup(v => v.Model).Returns(new ManageFootballPlayersViewModel());

            IEnumerable<Country> countries = new List<Country>();
            countryServiceMock.Setup(x => x.GetAllCountries()).Returns(countries);

            ManageFootballPlayersPresenter scoresPresenter = new ManageFootballPlayersPresenter(
                viewMock.Object,
                footballPlayerServiceMock.Object,
                countryServiceMock.Object,
                teamServiceMock.Object);

            viewMock.Raise(x => x.OnGetAllCoutries += null, EventArgs.Empty);

            CollectionAssert.AreEquivalent(countries, viewMock.Object.Model.Countries);
        }
    }
}
