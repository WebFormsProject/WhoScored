using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WhoScored.Models.Models
{
    public class LeagueTable
    {
        public LeagueTable()
        {
            this.TeamStatistics = new HashSet<TeamStatistic>();
        }

        public int Id { get; set; }

        public int LeagueId { get; set; }

        public virtual League League { get; set; }

        public int Season { get; set; }

        public ICollection<TeamStatistic> TeamStatistics { get; set; }
    }
}
