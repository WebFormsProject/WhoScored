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
    public class FootballPlayerService : IFootballPlayerService
    {
        private readonly IWhoScoredRepository<FootballPlayer> footballPlayerRepository;

        public FootballPlayerService(IWhoScoredRepository<FootballPlayer> footballPlayerRepository)
        {
            Guard.WhenArgument(footballPlayerRepository, "footballPlayerRepository").IsNull().Throw();
            this.footballPlayerRepository = footballPlayerRepository;
        }

        public IEnumerable<FootballPlayer> GetAllFootballPlayers()
        {
            IEnumerable<FootballPlayer> players = this.footballPlayerRepository.GetAll();

            return players;
        }

        public FootballPlayer GetFootballPlayerById(int id)
        {
            FootballPlayer foundPlayer = this.footballPlayerRepository.GetById(id);

            return foundPlayer;
        }
    }
}
