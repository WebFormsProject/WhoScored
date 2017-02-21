using System;
using System.Collections.Generic;
using WhoScored.Models.Models;
using WhoScored.Models.Models.Enums;

namespace WhoScored.Services.Contracts
{
    public interface IFootballPlayerService
    {
        IEnumerable<FootballPlayer> GetAllFootballPlayers();
        FootballPlayer GetFootballPlayerById(int id);

        void UpdateFootballPlayer(FootballPlayer footballPlayer);

        void AddFootballPlayer(string firstName,
            string lastName,
            string imagePath,
            PlayerPositionType position,
            int height,
            int weight,
            int shirtNumber,
            int countryId,
            int teamId,
            DateTime birthDate);

        void DeleteFootballPlayer(FootballPlayer footballPlayer);
    }
}
