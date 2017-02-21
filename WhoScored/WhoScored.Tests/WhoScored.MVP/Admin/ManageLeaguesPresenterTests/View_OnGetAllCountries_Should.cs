using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WhoScored.Models.Models;
using WhoScored.MVP.Admin;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.MVP.Admin.ManageLeaguesPresenterTests
{
    [TestFixture]
    public class View_OnGetAllCountries_Should
    {
        [Test]
        public void AppendCountriesCorrectly()
        {
            var viewMock = new Mock<IManageLeagueView>();
            var countryServiceMock = new Mock<ICountryService>();
            var leaugeServiceMock = new Mock<ILeagueService>();

            IEnumerable<Country> countries = new List<Country>() { new Country() };
            countryServiceMock.Setup(x => x.GetAllCountries()).Returns(countries);

            var model = new ManageLeagueViewModel();
            viewMock.Setup(x => x.Model).Returns(model);

            ManageLeaguePresenter presenter = new ManageLeaguePresenter(viewMock.Object, leaugeServiceMock.Object, countryServiceMock.Object);

            viewMock.Raise(x => x.OnGetAllCountries += null, EventArgs.Empty);

            CollectionAssert.AreEquivalent(countries, viewMock.Object.Model.Countries);
        }
    }
}
