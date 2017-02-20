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
        private readonly IUnitOfWork unitOfWork;

        public FootballPlayerService(IWhoScoredRepository<FootballPlayer> footballPlayerRepository, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(footballPlayerRepository, "footballPlayerRepository").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();
            this.footballPlayerRepository = footballPlayerRepository;
            this.unitOfWork = unitOfWork;
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
            using (this.unitOfWork)
            {
                this.footballPlayerRepository.Update(footballPlayer);
                this.unitOfWork.Commit();
            }
        }

        public void AddFootballPlayer(FootballPlayer footballPlayer)
        {
            using (this.unitOfWork)
            {
                this.footballPlayerRepository.Add(footballPlayer);
                this.unitOfWork.Commit();
            }
        }

        public void DeleteFootballPlayer(FootballPlayer footballPlayer)
        {
            using (this.unitOfWork)
            {
                this.footballPlayerRepository.Delete(footballPlayer);
                this.unitOfWork.Commit();
            }
        }
    }
}