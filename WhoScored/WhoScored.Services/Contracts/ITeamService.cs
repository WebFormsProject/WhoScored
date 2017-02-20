using System.Collections.Generic;
using WhoScored.Models.Models;

namespace WhoScored.Services.Contracts
{
    public interface ITeamService
    {
        Team GetTeamById(int id);

        IEnumerable<Team> GetAllTeams();
    }
}
