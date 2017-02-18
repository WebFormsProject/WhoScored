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

        public IEnumerable<IGrouping<League,Game>> GetGamesGroupedByLeague()
        {
            var groupedGames = this.gameRepository.GetAll().GroupBy(x => x.League);

            return groupedGames;
        }
    }
}
