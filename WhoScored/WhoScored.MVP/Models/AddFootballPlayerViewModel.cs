using System.Collections.Generic;
using WhoScored.Models.Models;

namespace WhoScored.MVP.Models
{
    public class AddFootballPlayerViewModel
    {
        public IEnumerable<FootballPlayer> FootballPlayers { get; set; }

        public IEnumerable<Country> Countries { get; set; } 

        public IEnumerable<Team> Teams { get; set; } 
    }
}
