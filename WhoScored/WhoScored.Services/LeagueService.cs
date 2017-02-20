using System.Collections.Generic;
using Bytes2you.Validation;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services.Contracts;

namespace WhoScored.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly IWhoScoredRepository<League> leagueRepository;

        public LeagueService(IWhoScoredRepository<League> leagueRepository)
        {
            Guard.WhenArgument(leagueRepository, "leagueRepository").IsNull().Throw();

            this.leagueRepository = leagueRepository;
        }

        public IEnumerable<League> GetAlLeagues()
        {
            return this.leagueRepository.GetAll();
        }

        public League GetLeagueById(int id)
        {
            return this.leagueRepository.GetById(id);
        }
    }
}
