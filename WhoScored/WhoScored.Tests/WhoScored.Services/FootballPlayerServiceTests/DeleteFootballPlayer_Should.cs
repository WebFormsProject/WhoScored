using System;
using Moq;
using NUnit.Framework;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.FootballPlayerServiceTests
{
    [TestFixture]
    public class DeleteFootballPlayer_Should
    {

        [Test]
        public void ThrowArgumentNullException_WhenPlayerIsNull()
        {
            var mockedRepository = new Mock<IWhoScoredRepository<FootballPlayer>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            IFootballPlayerService footballPlayerService = new FootballPlayerService(mockedRepository.Object, mockedUnitOfWork.Object);
            var exception = Assert.Throws<ArgumentNullException>(() => footballPlayerService.DeleteFootballPlayer(null));

            StringAssert.IsMatch("footballPlayer", exception.ParamName);
        }

        [Test]
        public void CallRepositoryUpdateMethodOnce_WhenPlayerIsValid()
        {
            var mockedRepository = new Mock<IWhoScoredRepository<FootballPlayer>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPlayer = new Mock<FootballPlayer>();

            IFootballPlayerService footballPlayerService = new FootballPlayerService(mockedRepository.Object, mockedUnitOfWork.Object);
            footballPlayerService.DeleteFootballPlayer(mockedPlayer.Object);

            mockedRepository.Verify(x => x.Delete(It.IsAny<FootballPlayer>()), Times.Once);
        }

        [Test]
        public void CallCommitMethodOnce_WhenPlayerIsValid()
        {
            var mockedRepository = new Mock<IWhoScoredRepository<FootballPlayer>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedPlayer = new Mock<FootballPlayer>();

            IFootballPlayerService footballPlayerService = new FootballPlayerService(mockedRepository.Object, mockedUnitOfWork.Object);
            footballPlayerService.DeleteFootballPlayer(mockedPlayer.Object);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
