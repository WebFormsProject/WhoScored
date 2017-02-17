using System.Collections.Generic;
using WhoScored.Models.Models;

namespace WhoScored.WebFormsClient.Models
{
    public class LeagueTablesViewModel
    {
        public LeagueTable LeagueTable { get; set; }

        public IEnumerable<TeamStatistic> TeamStatstics { get; set; }
    }
}