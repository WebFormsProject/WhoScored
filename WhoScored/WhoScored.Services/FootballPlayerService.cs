using System.Collections.Generic;
using Bytes2you.Validation;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services.Contracts;

namespace WhoScored.Services
{
    public class FootballPlayerService : IFootballPlayerService
    {
        private readonly IWhoScoredRepository<FootballPlayer> footballPlayerRepository;
        private readonly IWhoScoredContext context;

        public FootballPlayerService(IWhoScoredRepository<FootballPlayer> footballPlayerRepository, IWhoScoredContext context)
        {
            Guard.WhenArgument(footballPlayerRepository, "footballPlayerRepository").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.footballPlayerRepository = footballPlayerRepository;
            this.context = context;
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

        public void UpdateFootballPlayer(FootballPlayer footballPlayer)
        {
            this.footballPlayerRepository.Update(footballPlayer);
            context.SaveChanges();
        }
    }
}
