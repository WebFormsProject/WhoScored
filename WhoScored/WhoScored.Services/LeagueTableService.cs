using System;
using Bytes2you.Validation;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services.Contracts;

namespace WhoScored.Services
{
    public class LeagueTableService : ILeagueTableService
    {
        private readonly IWhoScoredRepository<LeagueTable> leagueTableRepository;

        public LeagueTableService(IWhoScoredRepository<LeagueTable> leagueTableRepository)
        {
            Guard.WhenArgument(leagueTableRepository, "leagueTableRepository").IsNull().Throw();

            this.leagueTableRepository = leagueTableRepository;
        }

        public LeagueTable GetLeagueTableById(int id)
        {
            return this.leagueTableRepository.GetById(id);
        }
    }
}
