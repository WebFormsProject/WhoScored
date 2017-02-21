using Moq;
using NUnit.Framework;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.TeamServiceTests
{
    [TestFixture]
    public class GetTeamById_Shoud
    {
        [Test]
        public void ReturnCorrectTeam_WhenPassedIdIsValid()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<Team>>();
            Team team = new Team()
            {
                Name = "Real Madrid",
                CountryId = 1,
                Coach = It.IsAny<Coach>(),
                EmblemImagePath = "/photos/Teams/real-madrid-la-liga.jpg"
            };

            repositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(team);

            ITeamService teamService = new TeamService(repositoryMock.Object);
            Team actualTeam = teamService.GetTeamById(It.IsAny<int>());

            Assert.AreSame(team, actualTeam);
        }

        [Test]
        public void ReturnNull_WhenPassedIdIsInvalid()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<Team>>();
            ITeamService teamService = new TeamService(repositoryMock.Object);

            int invalidTeamId = 33;
            Team resultTeam = teamService.GetTeamById(invalidTeamId);

            Assert.IsNull(resultTeam);
        }

        [Test]
        public void CallRepositoryMethodOnce_WhenPassedIdIsValid()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<Team>>();
            ITeamService teamService = new TeamService(repositoryMock.Object);

            teamService.GetTeamById(It.IsAny<int>());

            repositoryMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }
    }
}
