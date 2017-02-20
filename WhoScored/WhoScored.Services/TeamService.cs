using System;
using System.Collections.Generic;
using Bytes2you.Validation;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services.Contracts;

namespace WhoScored.Services
{
    public class TeamService : ITeamService
    {
        private readonly IWhoScoredRepository<Team> teamRepository;

        public TeamService(IWhoScoredRepository<Team> teamRepository)
        {
            Guard.WhenArgument(teamRepository, "teamRepository").IsNull().Throw();

            this.teamRepository = teamRepository;
        }

        public Team GetTeamById(int id)
        {
            return this.teamRepository.GetById(id);
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return this.teamRepository.GetAll();
        }
    }
}
