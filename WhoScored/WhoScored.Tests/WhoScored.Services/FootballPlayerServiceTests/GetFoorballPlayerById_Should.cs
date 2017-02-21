using Moq;
using NUnit.Framework;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.FootballPlayerServiceTests
{
    [TestFixture]
    public class GetFootballPlayerById_Should
    {
        [Test]
        public void ReturnNull_WhenPlayerWithSuchIdDoesNotExist()
        {
            var mockedRepository = new Mock<IWhoScoredRepository<FootballPlayer>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            IFootballPlayerService footballPlayerService = new FootballPlayerService(mockedRepository.Object, mockedUnitOfWork.Object);
            FootballPlayer footballPlayer = footballPlayerService.GetFootballPlayerById(8);

            Assert.IsNull(footballPlayer);
        }

        [Test]
        public void ReturnCorrectFootballPlayer_WhenIdIsValid()
        {
            var id = 8;
            FootballPlayer player = new FootballPlayer();

            var mockedRepository = new Mock<IWhoScoredRepository<FootballPlayer>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            IFootballPlayerService footballPlayerService = new FootballPlayerService(mockedRepository.Object, mockedUnitOfWork.Object);
            mockedRepository.Setup(x => x.GetById(id)).Returns(player);

            FootballPlayer actualFootballPlayer = footballPlayerService.GetFootballPlayerById(8);
            Assert.AreSame(player, actualFootballPlayer);
        }
    }
}
