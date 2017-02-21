using System;
using Moq;
using NUnit.Framework;
using WhoScored.MVP.Admin;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.MVP.Admin.ManageLeaguesPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenILeagueServiceIsNull()
        {
            var viewMock = new Mock<IManageLeagueView>();
            var countryServiceMock = new Mock<ICountryService>();

            var exception = Assert.Throws<ArgumentNullException>(() => new ManageLeaguePresenter(viewMock.Object, null, countryServiceMock.Object));

            StringAssert.IsMatch("leagueService", exception.ParamName);
        }

        [Test]
        public void ThrowArgumentNullException_WhenICountryServiceIsNull()
        {
            var viewMock = new Mock<IManageLeagueView>();
            var leaugeServiceMock = new Mock<ILeagueService>();

            var exception = Assert.Throws<ArgumentNullException>(() => new ManageLeaguePresenter(viewMock.Object, leaugeServiceMock.Object, null));

            StringAssert.IsMatch("countryService", exception.ParamName);
        }

        [Test]
        public void CreateInstance_WhenParametersAreValid()
        {
            var viewMock = new Mock<IManageLeagueView>();
            var countryServiceMock = new Mock<ICountryService>();
            var leaugeServiceMock = new Mock<ILeagueService>();

            ManageLeaguePresenter presenter = new ManageLeaguePresenter(viewMock.Object, leaugeServiceMock.Object, countryServiceMock.Object);

            Assert.IsInstanceOf<ManageLeaguePresenter>(presenter);
        }
    }
}