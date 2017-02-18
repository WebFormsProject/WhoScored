using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services.Contracts;

namespace WhoScored.Services
{
    public class GameService : IGameService
    {
        private readonly IWhoScoredRepository<Game> gameRepository;

        public GameService(IWhoScoredRepository<Game> gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public IEnumerable<League> GetGroupedLeagues()
        {
            var groupedLeagues = this.gameRepository.GetAll().GroupBy(x => x.League).Select(x => x.Key);

            return groupedLeagues;
        }

        public IEnumerable<Game> GetGamesByLeague(League league)
        {
            var groupedGames = this.gameRepository.GetAll().Where(x => x.League == league);

            return groupedGames;
        }
    }
}
