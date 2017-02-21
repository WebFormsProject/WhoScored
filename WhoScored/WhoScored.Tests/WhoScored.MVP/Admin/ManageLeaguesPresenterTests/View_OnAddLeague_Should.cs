using System;
using System.Web.ModelBinding;
using Moq;
using NUnit.Framework;
using WhoScored.Models.Models;
using WhoScored.MVP.Admin;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.MVP.Admin.ManageLeaguesPresenterTests
{
    [TestFixture]
    public class View_OnAddLeague_Should
    {
        [Test]
        public void CallAddLeagueMethodOnce_WhenItemIsValid()
        {
            var viewMock = new Mock<IManageLeagueView>();
            var countryServiceMock = new Mock<ICountryService>();
            var leaugeServiceMock = new Mock<ILeagueService>();

            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            ManageLeaguePresenter presenter = new ManageLeaguePresenter(viewMock.Object, leaugeServiceMock.Object,
                countryServiceMock.Object);

            viewMock.Raise(x => x.OnAddLeague += null, EventArgs.Empty);
            
            leaugeServiceMock.Verify(x=>x.AddNewLeague(It.IsAny<League>()), Times.Once);
        }

        [Test]
        public void NotCallAddLeagueMethod_WhenItemStateIsInvalid()
        {
            var viewMock = new Mock<IManageLeagueView>();
            var countryServiceMock = new Mock<ICountryService>();
            var leaugeServiceMock = new Mock<ILeagueService>();

            var modelState = new ModelStateDictionary();
            modelState.AddModelError("test", "more test");
            viewMock.Setup(x => x.ModelState).Returns(modelState);

            ManageLeaguePresenter presenter = new ManageLeaguePresenter(viewMock.Object, leaugeServiceMock.Object,
                countryServiceMock.Object);

            viewMock.Raise(x => x.OnAddLeague += null, EventArgs.Empty);

            leaugeServiceMock.Verify(x => x.AddNewLeague(It.IsAny<League>()), Times.Never);
        }

        [Test]
        public void CallTryUpdateViewMethodOnce_WhenItemIsValid()
        {
            var viewMock = new Mock<IManageLeagueView>();
            var countryServiceMock = new Mock<ICountryService>();
            var leaugeServiceMock = new Mock<ILeagueService>();

            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            ManageLeaguePresenter presenter = new ManageLeaguePresenter(viewMock.Object, leaugeServiceMock.Object,
                countryServiceMock.Object);

            viewMock.Raise(x => x.OnAddLeague += null, EventArgs.Empty);

            viewMock.Verify(x=>x.TryUpdateModel(It.IsAny<League>()), Times.Once);
        }
    }
}
