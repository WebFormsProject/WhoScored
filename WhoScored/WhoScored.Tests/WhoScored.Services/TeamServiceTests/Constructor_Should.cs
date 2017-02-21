using NUnit.Framework;
using System;
using Moq;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.TeamServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedRepositoryIsNull()
        {
            var actualMessage = Assert.Throws<ArgumentNullException>(() => new TeamService(null));

            StringAssert.IsMatch("teamRepository", actualMessage.ParamName);
        }

        [Test]
        public void CreateCorrectInstanceOfTeamService_WhenPassedArgumentsAreValid()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<Team>>();

            ITeamService teamService = new TeamService(repositoryMock.Object);

            Assert.IsInstanceOf<TeamService>(teamService);
        }
    }
}
