using Moq;
using NUnit.Framework;
using System;
using WhoScored.Models.Models.Enums;
using WhoScored.MVP.Admin;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Presenters;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.MVP.Admin.ManageFootballPlayersPresenterTests
{
    [TestFixture]
    public class View_OnAddFootballPlayer_Should
    {
        [Test]
        public void CallAddFootballPlayerMethodOnce_WhenItemIsValid()
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

            string firstName = "test";
            string lastName = "test";
            string position = "Defender";
            string imagePath = "test";
            int heigth = 5;
            int weidth = 5;
            int shirtNumber = 5;
            int countryId = 5;
            int teamId = 5;
            DateTime birthDate = new DateTime();
            AddPlayerEventArgs eventArguments = new AddPlayerEventArgs(
                firstName,
                lastName,
                imagePath,
                position,
                heigth,
                weidth,
                shirtNumber,
                countryId,
                teamId,
                birthDate);
            viewMock.Raise(x => x.OnAddFootballPlayer += null, eventArguments);


            footballPlayerServiceMock.Verify(x => x.AddFootballPlayer(
                firstName,
                lastName,
                imagePath,
                PlayerPositionType.Defender,
                heigth,
                weidth,
                shirtNumber,
                countryId,
                teamId,
                birthDate), Times.Once);
        }
    }
}
