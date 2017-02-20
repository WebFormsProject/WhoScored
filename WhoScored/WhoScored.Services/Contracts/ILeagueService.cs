using System.Collections.Generic;
using WhoScored.Models.Models;

namespace WhoScored.Services.Contracts
{
    public interface ILeagueService
    {
        IEnumerable<League> GetAlLeagues();

        League GetLeagueById(int id);
    }
}
