﻿using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.TeamServiceTests
{
    public class GetAll_Should
    {
        [Test]
        public void GetAllTeams()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<Team>>();
            ITeamService teamService = new TeamService(repositoryMock.Object);

            IEnumerable<Team> teams = new List<Team>()
            {
                new Team()
                {
                    Name = "Real Madrid",
                    CountryId = 1,
                    Coach = It.IsAny<Coach>(),
                    EmblemImagePath = "/photos/Teams/real-madrid-la-liga.jpg"
                },
                new Team()
                {
                    Name = "Arsenal",
                    CountryId = 1,
                    Coach = It.IsAny<Coach>(),
                    EmblemImagePath = "/photos/Teams/arsenal-premier-league.png"
                }};

            repositoryMock.Setup(x => x.GetAll()).Returns(teams);
            IEnumerable<Team> actualTeams = teamService.GetAllTeams();

            CollectionAssert.AreEquivalent(teams, actualTeams);
        }

        [Test]
        public void CallRepositoryMethodOnce()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<Team>>();
            ITeamService teamService = new TeamService(repositoryMock.Object);

            teamService.GetAllTeams();

            repositoryMock.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
