using System.Collections.Generic;
using WhoScored.Models.Models;

namespace WhoScored.Services.Contracts
{
    public interface IFootballPlayerService
    {
        IEnumerable<FootballPlayer> GetAllFootballPlayers();
        FootballPlayer GetFootballPlayerById(int id);
    }
}
