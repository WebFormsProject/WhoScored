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
        private readonly IWhoScoredRepository<FootballPlayer> footballPlayeRepository;

        public FootballPlayerService(IWhoScoredRepository<FootballPlayer> footballPlayeRepository)
        {
            Guard.WhenArgument(footballPlayeRepository, "footballPlayeRepository").IsNull().Throw();
            this.footballPlayeRepository = footballPlayeRepository;
        }

        public FootballPlayer GetFootballPlayerById(int id)
        {
            FootballPlayer foundPlayer = this.footballPlayeRepository.GetById(id);

            return foundPlayer;
        }
    }
}
