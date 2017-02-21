using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Models.Models.Enums;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.FootballPlayerServiceTests
{
    [TestFixture]
    public class AddFootballPlayer_Should
    {
        [Test]
        public void CallRepositoryUpdateMethodOnce_WhenPlayerIsValid()
        {
            var mockedRepository = new Mock<IWhoScoredRepository<FootballPlayer>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            IFootballPlayerService footballPlayerService = new FootballPlayerService(mockedRepository.Object, mockedUnitOfWork.Object);
            footballPlayerService.AddFootballPlayer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<PlayerPositionType>()
                , It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>());

            mockedRepository.Verify(x => x.Add(It.IsAny<FootballPlayer>()), Times.Once);
        }

        [Test]
        public void CallCommitMethodOnce_WhenPlayerIsValid()
        {
            var mockedRepository = new Mock<IWhoScoredRepository<FootballPlayer>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            IFootballPlayerService footballPlayerService = new FootballPlayerService(mockedRepository.Object, mockedUnitOfWork.Object);
            footballPlayerService.AddFootballPlayer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<PlayerPositionType>()
                , It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>());

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void CallDisposeMethodOnce_WhenPlayerIsValid()
        {
            var mockedRepository = new Mock<IWhoScoredRepository<FootballPlayer>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            IFootballPlayerService footballPlayerService = new FootballPlayerService(mockedRepository.Object, mockedUnitOfWork.Object);
            footballPlayerService.AddFootballPlayer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<PlayerPositionType>()
                , It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>());

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
