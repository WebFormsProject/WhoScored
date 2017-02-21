using System.Collections.Generic;
using WhoScored.Models.Models;

namespace WhoScored.Services.Contracts
{
    public interface IGameService
    {
        IEnumerable<Game> GetGamesByLeague(League league);

        Game GetGameById(int id);
    }
}
