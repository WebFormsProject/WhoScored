using System;
using Moq;
using NUnit.Framework;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.MVP.LeaguePresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenILeagueServiceIsNull()
        {
            var viewMock = new Mock<ILeaguesView>();

            var exception = Assert.Throws<ArgumentNullException>(() => new LeaguePresenter(viewMock.Object, null));

            StringAssert.IsMatch("leagueService", exception.ParamName);
        }

        [Test]
        public void CreateInstance_WhenParametersAreValid()
        {
            var viewMock = new Mock<ILeaguesView>();
            var leagueServiceMock = new Mock<ILeagueService>();

            LeaguePresenter presenter = new LeaguePresenter(viewMock.Object, leagueServiceMock.Object);

            Assert.IsInstanceOf<LeaguePresenter>(presenter);
        }
    }
}
