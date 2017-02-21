using Moq;
using NUnit.Framework;
using System.Web.ModelBinding;
using WhoScored.Models.Models;
using WhoScored.MVP.Admin;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Presenters;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.MVP.Admin.ManageFootballPlayersPresenterTests
{
    [TestFixture]
    public class View_OnUpdateFootballPlayer_Should
    {
        [Test]
        public void CallUpdateFootballPlayerMethodOnce_WhenItemIsFoundAndStateValid()
        {
            var viewMock = new Mock<IManageFootballPlayersView>();
            var footballPlayerServiceMock = new Mock<IFootballPlayerService>();
            var countryServiceMock = new Mock<ICountryService>();
            var teamServiceMock = new Mock<ITeamService>();

            viewMock.Setup(x => x.Model).Returns(new ManageFootballPlayersViewModel());
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            FootballPlayer footballPlayer = new FootballPlayer();
            footballPlayerServiceMock.Setup(x => x.GetFootballPlayerById(It.IsAny<int>())).Returns(footballPlayer);

            ManageFootballPlayersPresenter presenter = new ManageFootballPlayersPresenter(
                viewMock.Object,
                footballPlayerServiceMock.Object,
                countryServiceMock.Object,
                teamServiceMock.Object);

            viewMock.Raise(x => x.OnUpdateFootballPlayer += null, new IdEventArgs(It.IsAny<int>()));

            footballPlayerServiceMock.Verify(x => x.UpdateFootballPlayer(footballPlayer), Times.Once);
        }

        [Test]
        public void NotCallUpdateFootbalPlayer_WhenItemIsNotFound()
        {
            var viewMock = new Mock<IManageFootballPlayersView>();
            var footballPlayerServiceMock = new Mock<IFootballPlayerService>();
            var countryServiceMock = new Mock<ICountryService>();
            var teamServiceMock = new Mock<ITeamService>();

            ManageFootballPlayersPresenter presenter = new ManageFootballPlayersPresenter(
               viewMock.Object,
               footballPlayerServiceMock.Object,
               countryServiceMock.Object,
               teamServiceMock.Object);

            viewMock.Setup(x => x.Model).Returns(new ManageFootballPlayersViewModel());
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            footballPlayerServiceMock.Verify(x => x.UpdateFootballPlayer(It.IsAny<FootballPlayer>()), Times.Never);
        }

        [Test]
        public void CallTryUpdateViewMethodOnce_WhenItemIsValid()
        {
            var viewMock = new Mock<IManageFootballPlayersView>();
            var footballPlayerServiceMock = new Mock<IFootballPlayerService>();
            var countryServiceMock = new Mock<ICountryService>();
            var teamServiceMock = new Mock<ITeamService>();

            viewMock.Setup(x => x.Model).Returns(new ManageFootballPlayersViewModel());
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            FootballPlayer footballPlayer = new FootballPlayer();
            footballPlayerServiceMock.Setup(x => x.GetFootballPlayerById(It.IsAny<int>())).Returns(footballPlayer);

            ManageFootballPlayersPresenter presenter = new ManageFootballPlayersPresenter(
               viewMock.Object,
               footballPlayerServiceMock.Object,
               countryServiceMock.Object,
               teamServiceMock.Object);

            viewMock.Raise(x => x.OnUpdateFootballPlayer += null, new IdEventArgs(It.IsAny<int>()));

            viewMock.Verify(x => x.TryUpdateModel(It.IsAny<FootballPlayer>()), Times.Once);
        }

        [Test]
        public void NotCallTryUpdateModelMethod_WhenItemIsNotFound()
        {
            var viewMock = new Mock<IManageFootballPlayersView>();
            var footballPlayerServiceMock = new Mock<IFootballPlayerService>();
            var countryServiceMock = new Mock<ICountryService>();
            var teamServiceMock = new Mock<ITeamService>();

            viewMock.Setup(x => x.Model).Returns(new ManageFootballPlayersViewModel());
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            ManageFootballPlayersPresenter presenter = new ManageFootballPlayersPresenter(
                viewMock.Object,
                footballPlayerServiceMock.Object,
                countryServiceMock.Object,
                teamServiceMock.Object);

            viewMock.Raise(x => x.OnUpdateFootballPlayer += null, new IdEventArgs(It.IsAny<int>()));

            viewMock.Verify(x => x.TryUpdateModel(It.IsAny<FootballPlayer>()), Times.Never);
        }

        [Test]
        public void AddModelError_WhenItemIsNotFound()
        {
            var viewMock = new Mock<IManageFootballPlayersView>();
            var footballPlayerServiceMock = new Mock<IFootballPlayerService>();
            var countryServiceMock = new Mock<ICountryService>();
            var teamServiceMock = new Mock<ITeamService>();

            int id = 33;
            string expectedString = $"Item with id {id} was not found";
            viewMock.Setup(v => v.ModelState).Returns(new ModelStateDictionary());

            ManageFootballPlayersPresenter presenter = new ManageFootballPlayersPresenter(
               viewMock.Object,
               footballPlayerServiceMock.Object,
               countryServiceMock.Object,
               teamServiceMock.Object);

            viewMock.Raise(x => x.OnUpdateFootballPlayer += null, new IdEventArgs(id));

            Assert.AreEqual(expectedString, viewMock.Object.ModelState[""].Errors[0].ErrorMessage);
        }
    }
}
