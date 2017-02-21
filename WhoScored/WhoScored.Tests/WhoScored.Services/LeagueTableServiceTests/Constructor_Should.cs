using Moq;
using NUnit.Framework;
using System;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.LeagueTableServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedRepositoryIsNull()
        {
            var actualMessage = Assert.Throws<ArgumentNullException>(() => new LeagueTableService(null));

            StringAssert.IsMatch("leagueTableRepository", actualMessage.ParamName);
        }

        [Test]
        public void CreateCorrectInstanceOfLeagueTablemService_WhenPassedArgumentsAreValid()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<LeagueTable>>();

            ILeagueTableService leagueTableService = new LeagueTableService(repositoryMock.Object);

            Assert.IsInstanceOf<LeagueTableService>(leagueTableService);
        }
    }
}
