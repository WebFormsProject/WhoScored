using Moq;
using NUnit.Framework;
using WhoScored.Models.Models;
using WhoScored.MVP.Models;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.MVP.LeagueTablePresenterTests
{
    [TestFixture]
    public class View_OnGetLeaguesTable_Should
    {
        [Test]
        public void SetLeagueTableToViewModel_WhenView_OnGetLeaguesTableIsRaised()
        {
            var viewMock = new Mock<ILeagueTableView>();
            var leagueServiceMock = new Mock<ILeagueTableService>();

            LeagueTable leagueTable = new LeagueTable();
            leagueServiceMock.Setup(x => x.GetLeagueTableById(It.IsAny<int>())).Returns(leagueTable);

            LeagueTablesViewModel model = new LeagueTablesViewModel();
            viewMock.Setup(x => x.Model).Returns(model);
            LeagueTablePresenter presenter = new LeagueTablePresenter(viewMock.Object, leagueServiceMock.Object);


            viewMock.Raise(x => x.OnGetLeagueTableData += null, new IdEventArgs(8));

            Assert.AreEqual(leagueTable, viewMock.Object.Model.LeagueTable);
        }
    }
}
