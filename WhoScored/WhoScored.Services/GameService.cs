using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;
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
            Guard.WhenArgument(gameRepository, "gameRepository").IsNull().Throw();

            this.gameRepository = gameRepository;
        }

        public IEnumerable<Game> GetGamesByLeague(League league)
        {
            Guard.WhenArgument(league, "league").IsNull().Throw();
            var groupedGames = this.gameRepository.GetAll().Where(x => x.League == league);

            return groupedGames;
        }

        public Game GetGameById(int id)
        {
            Game game = this.gameRepository.GetById(id);

            return game;
        }
    }
}
