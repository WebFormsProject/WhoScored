using System.Collections.Generic;
using WhoScored.Models.Models;

namespace WhoScored.MVP.Models
{
    public class AddFootballPlayerViewModel
    {
        public IEnumerable<FootballPlayer> FootballPlayers { get; set; }
    }
}
