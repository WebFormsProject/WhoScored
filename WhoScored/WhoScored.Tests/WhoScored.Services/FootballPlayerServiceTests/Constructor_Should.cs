using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.FootballPlayerServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedIRepositoryArgumentIsNull()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var actualMessage = Assert.Throws<ArgumentNullException>(() => new FootballPlayerService(null, mockedUnitOfWork.Object));

            StringAssert.IsMatch("footballPlayerRepository", actualMessage.ParamName);
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedIUnitOfWorkArgumentIsNull()
        {
            var mockedRepository = new Mock<IWhoScoredRepository<FootballPlayer>>();
            var actualMessage = Assert.Throws<ArgumentNullException>(() => new FootballPlayerService(mockedRepository.Object, null));

            StringAssert.IsMatch("unitOfWork", actualMessage.ParamName);
        }

        [Test]
        public void CreateCorrectInstanceOfCountryService_WhenPassedArgumentIsValid()
        {
            var mockedRepository = new Mock<IWhoScoredRepository<FootballPlayer>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            IFootballPlayerService footballPlayerService = new FootballPlayerService(mockedRepository.Object, mockedUnitOfWork.Object);

            Assert.IsInstanceOf<FootballPlayerService>(footballPlayerService);
        }
    }
}
