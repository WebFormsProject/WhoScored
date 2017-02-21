using System;
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
    public class View_OnGetAllLeagues_Should
    {
        [Test]
        public void AppendLeaguesCorrectly()
        {
            var viewMock = new Mock<IManageLeagueView>();
            var countryServiceMock = new Mock<ICountryService>();
            var leaugeServiceMock = new Mock<ILeagueService>();

            IEnumerable<League> leagues = new List<League>() { new League() };
            leaugeServiceMock.Setup(x => x.GetAlLeagues()).Returns(leagues);

            var model = new ManageLeagueViewModel();
            viewMock.Setup(x => x.Model).Returns(model);

            ManageLeaguePresenter presenter = new ManageLeaguePresenter(viewMock.Object, leaugeServiceMock.Object, countryServiceMock.Object);

            viewMock.Raise(x => x.OnGetAllLeagues += null, EventArgs.Empty);

            CollectionAssert.AreEquivalent(leagues, viewMock.Object.Model.Leagues);
        }
    }
}
