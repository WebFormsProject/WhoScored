using Moq;
using NUnit.Framework;
using System;
using WhoScored.MVP.Models;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.MVP.TeamPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedServiceIsNull()
        {
            var viewMock = new Mock<ITeamView>();
            viewMock.Setup(v => v.Model).Returns(new TeamViewModel());

            var actualMessage = Assert.Throws<ArgumentNullException>(() => new TeamPresenter(viewMock.Object, null));

            StringAssert.IsMatch("teamService", actualMessage.ParamName);
        }

        [Test]
        public void CreateCorrectInstanceOfTeamPresenter_WhenPassedArgumentsAreValid()
        {
            var teamServiceMock = new Mock<ITeamService>();
            var viewMock = new Mock<ITeamView>();
            viewMock.Setup(v => v.Model).Returns(new TeamViewModel());

            TeamPresenter teamPresenter = new TeamPresenter(viewMock.Object,teamServiceMock.Object);

            Assert.IsInstanceOf<TeamPresenter>(teamPresenter);
        }
    }
}
