using Moq;
using NUnit.Framework;
using WhoScored.Models.Models;
using WhoScored.MVP.Models;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.MVP.FootballPlayerPresenterTests
{
    [TestFixture]
    public class View_OnGetFootballPlayerById_Should
    {
        [Test]
        public void SetFootballPlayerToViewModel_WhenOnGetFootballPlayerByIdIsRaised()
        {
            var viewMock = new Mock<IFootballPlayerView>();
            var footballServiceMock = new Mock<IFootballPlayerService>();

            FootballPlayer footballPlayer = new FootballPlayer();
            footballServiceMock.Setup(x => x.GetFootballPlayerById(It.IsAny<int>())).Returns(footballPlayer);

            FootballPlayerViewModel model = new FootballPlayerViewModel();
            viewMock.Setup(x => x.Model).Returns(model);

            FootballPlayerPresenter presenter = new FootballPlayerPresenter(viewMock.Object, footballServiceMock.Object);

            viewMock.Raise(x => x.OnGetFootballPlayerById += null, new IdEventArgs(8));

            Assert.AreEqual(footballPlayer, viewMock.Object.Model.FootballPlayer);
        }
    }
}
