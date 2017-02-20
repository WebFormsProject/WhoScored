using WhoScored.Models.Models;

namespace WhoScored.Services.Contracts
{
    public interface ILeagueTableService
    {
        LeagueTable GetLeagueTableById(int id);
    }
}
