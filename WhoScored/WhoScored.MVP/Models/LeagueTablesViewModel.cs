using System.Collections.Generic;
using WhoScored.Models.Models;

namespace WhoScored.MVP.Models
{
    public class LeagueTablesViewModel
    {
        public LeagueTable LeagueTable { get; set; }

        public IEnumerable<TeamStatistic> TeamStatstics { get; set; }
    }
}