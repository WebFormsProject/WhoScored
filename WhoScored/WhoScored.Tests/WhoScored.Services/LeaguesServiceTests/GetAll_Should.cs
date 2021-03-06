﻿using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.LeaguesServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void GetAllLeagues()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<League>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            ILeagueService leagueService = new LeagueService(repositoryMock.Object, unitOfWorkMock.Object);

            IEnumerable<League> leagues = new List<League>();
            repositoryMock.Setup(x => x.GetAll()).Returns(leagues);

            IEnumerable<League> actualLeagues = leagueService.GetAlLeagues();

            CollectionAssert.AreEquivalent(leagues, actualLeagues);
        }

        [Test]
        public void CallRepositoryMethodOnce()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<League>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            ILeagueService leagueService = new LeagueService(repositoryMock.Object, unitOfWorkMock.Object);

            leagueService.GetAlLeagues();

            repositoryMock.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
