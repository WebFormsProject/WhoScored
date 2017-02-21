using System;
using Moq;
using NUnit.Framework;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.MVP.LeagueTablePresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenILeagueTableServiceIsNull()
        {
            var viewMock = new Mock<ILeagueTableView>();

            var exception = Assert.Throws<ArgumentNullException>(() => new LeagueTablePresenter(viewMock.Object, null));

            StringAssert.IsMatch("leagueTableService", exception.ParamName);
        }

        [Test]
        public void CreateInstance_WhenParametersAreValid()
        {
            var viewMock = new Mock<ILeagueTableView>();
            var leagueServiceMock = new Mock<ILeagueTableService>();

            LeagueTablePresenter presenter = new LeagueTablePresenter(viewMock.Object, leagueServiceMock.Object);

            Assert.IsInstanceOf<LeagueTablePresenter>(presenter);
        }
    }
}
