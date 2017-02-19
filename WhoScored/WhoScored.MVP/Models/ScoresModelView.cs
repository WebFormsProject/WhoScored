using System.Collections.Generic;
using WhoScored.Models.Models;

namespace WhoScored.MVP.Models
{
    public class ScoresModelView
    {
        public IEnumerable<League> Leagues { get; set; }

        public IEnumerable<Game> GamesByLeague { get; set; }

        public Game Game { get; set; }
    }
}