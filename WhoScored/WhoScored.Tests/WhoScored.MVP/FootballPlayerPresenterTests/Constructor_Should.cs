using System;
using Moq;
using NUnit.Framework;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.MVP.FootballPlayerPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIFootballPlayerServiceIsNull()
        {
            var viewMock = new Mock<IFootballPlayerView>();

            var exception = Assert.Throws<ArgumentNullException>(() => new FootballPlayerPresenter(viewMock.Object, null));

            StringAssert.IsMatch("footballPlayerService", exception.ParamName);
        }

        [Test]
        public void CreateInstance_WhenParametersAreValid()
        {
            var viewMock = new Mock<IFootballPlayerView>();
            var footballServiceMock = new Mock<IFootballPlayerService>();

            FootballPlayerPresenter presenter = new FootballPlayerPresenter(viewMock.Object, footballServiceMock.Object);

            Assert.IsInstanceOf<FootballPlayerPresenter>(presenter);}
    }
}
