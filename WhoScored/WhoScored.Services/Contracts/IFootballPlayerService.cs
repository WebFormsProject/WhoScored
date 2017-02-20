using System.Collections.Generic;
using WhoScored.Models.Models;

namespace WhoScored.Services.Contracts
{
    public interface IFootballPlayerService
    {
        IEnumerable<FootballPlayer> GetAllFootballPlayers();
        FootballPlayer GetFootballPlayerById(int id);

        void UpdateFootballPlayer(FootballPlayer footballPlayer);

        void AddFootballPlayer(FootballPlayer footballPlayer);

        void DeleteFootballPlayer(FootballPlayer footballPlayer);
    }
}
