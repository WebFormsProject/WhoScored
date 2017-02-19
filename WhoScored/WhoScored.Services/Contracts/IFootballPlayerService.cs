using WhoScored.Models.Models;

namespace WhoScored.Services.Contracts
{
    public interface IFootballPlayerService
    {
        FootballPlayer GetFootballPlayerById(int id);
    }
}
