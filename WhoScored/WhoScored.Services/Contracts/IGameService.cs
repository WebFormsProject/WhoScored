using System.Collections.Generic;
using System.Linq;
using WhoScored.Models.Models;

namespace WhoScored.Services.Contracts
{
    public interface IGameService
    {
        IEnumerable<IGrouping<League, Game>> GetGamesGroupedByLeague();
    }
}
