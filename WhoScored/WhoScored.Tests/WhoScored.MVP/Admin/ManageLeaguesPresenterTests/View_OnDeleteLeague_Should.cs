﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using Moq;
using NUnit.Framework;
using WhoScored.Models.Models;
using WhoScored.MVP.Admin;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.MVP.Admin.ManageLeaguesPresenterTests
{
    [TestFixture]
    public class View_OnDeleteLeague_Should
    {
        [Test]
        public void CallDeleteMethodOnce_WhenLeagueIsFound()
        {
            var viewMock = new Mock<IManageLeagueView>();
            var countryServiceMock = new Mock<ICountryService>();
            var leaugeServiceMock = new Mock<ILeagueService>();

            League league = new League();
            leaugeServiceMock.Setup(x => x.GetLeagueById(It.IsAny<int>())).Returns(league);

            viewMock.Setup(x => x.ModelState).Returns(new ModelStateDictionary());

            ManageLeaguePresenter presenter = new ManageLeaguePresenter(viewMock.Object, leaugeServiceMock.Object,
            countryServiceMock.Object);

            viewMock.Raise(x=>x.OnDeleteLeague += null, new IdEventArgs(It.IsAny<int>()));

            leaugeServiceMock.Verify(x=>x.DeleteLeague(It.IsAny<League>()), Times.Once);
        }

        [Test]
        public void NotCallDeleteLeague_WhenItemIsNotFound()
        {
            var viewMock = new Mock<IManageLeagueView>();
            var countryServiceMock = new Mock<ICountryService>();
            var leaugeServiceMock = new Mock<ILeagueService>();

            ManageLeaguePresenter presenter = new ManageLeaguePresenter(viewMock.Object, leaugeServiceMock.Object,
               countryServiceMock.Object);

            viewMock.Setup(x => x.ModelState).Returns(new ModelStateDictionary());

            leaugeServiceMock.Verify(x => x.DeleteLeague(It.IsAny<League>()), Times.Never);
        }

        [Test]
        public void CallTryUpdateViewMethodOnce_WhenItemIsValid()
        {
            var viewMock = new Mock<IManageLeagueView>();
            var countryServiceMock = new Mock<ICountryService>();
            var leaugeServiceMock = new Mock<ILeagueService>();

            var model = new ManageLeagueViewModel();
            viewMock.Setup(x => x.Model).Returns(model);
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            League league = new League();
            leaugeServiceMock.Setup(x => x.GetLeagueById(It.IsAny<int>())).Returns(league);

            ManageLeaguePresenter presenter = new ManageLeaguePresenter(viewMock.Object, leaugeServiceMock.Object,
                countryServiceMock.Object);

            viewMock.Raise(x => x.OnDeleteLeague += null, new IdEventArgs(It.IsAny<int>()));

            viewMock.Verify(x => x.TryUpdateModel(It.IsAny<League>()), Times.Once);
        }

        [Test]
        public void NotCallTryUpdateModelMethod_WhenLeagueIsNotFound()
        {
            var viewMock = new Mock<IManageLeagueView>();
            var countryServiceMock = new Mock<ICountryService>();
            var leaugeServiceMock = new Mock<ILeagueService>();

            var model = new ManageLeagueViewModel();
            viewMock.Setup(x => x.Model).Returns(model);
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            ManageLeaguePresenter presenter = new ManageLeaguePresenter(viewMock.Object, leaugeServiceMock.Object,
                countryServiceMock.Object);

            viewMock.Raise(x => x.OnDeleteLeague += null, new IdEventArgs(8));

            viewMock.Verify(x => x.TryUpdateModel(It.IsAny<League>()), Times.Never);
        }

        [Test]
        public void AddModelError_WhenLeagueIsNotFound()
        {
            var viewMock = new Mock<IManageLeagueView>();
            var countryServiceMock = new Mock<ICountryService>();
            var leaugeServiceMock = new Mock<ILeagueService>();

            int id = 8;
            string expectedString = String.Format("Item with id {0} was not found", id);
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            ManageLeaguePresenter presenter = new ManageLeaguePresenter(viewMock.Object, leaugeServiceMock.Object,
              countryServiceMock.Object);

            viewMock.Raise(x => x.OnDeleteLeague += null, new IdEventArgs(id));

            Assert.AreEqual(expectedString, viewMock.Object.ModelState[""].Errors[0].ErrorMessage);
        }
    }
}
