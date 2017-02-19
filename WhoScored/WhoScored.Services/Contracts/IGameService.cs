using System.Collections.Generic;
using System.Linq;
using WhoScored.Models.Models;

namespace WhoScored.Services.Contracts
{
    public interface IGameService
    {
        IEnumerable<League> GetGroupedLeagues();

        IEnumerable<Game> GetGamesByLeague(League league);

        Game GetGameById(int id);
    }
}
