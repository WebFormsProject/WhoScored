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
        private readonly IUnitOfWork unitOfWork;

        public LeagueService(IWhoScoredRepository<League> leagueRepository, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(leagueRepository, "leagueRepository").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

            this.leagueRepository = leagueRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<League> GetAlLeagues()
        {
            return this.leagueRepository.GetAll();
        }

        public League GetLeagueById(int id)
        {
            return this.leagueRepository.GetById(id);
        }

        public void AddNewLeague(League league)
        {
            using (this.unitOfWork)
            {
                this.leagueRepository.Add(league);
                this.unitOfWork.Commit();
            }
        }

        public void UpdateLeague(League league)
        {
            using (this.unitOfWork)
            {
                this.leagueRepository.Update(league);
                this.unitOfWork.Commit();
            }
        }

        public void DeleteLeague(League league)
        {
            using (this.unitOfWork)
            {
                this.leagueRepository.Delete(league);
                this.unitOfWork.Commit();
            }
        }
    }
}
