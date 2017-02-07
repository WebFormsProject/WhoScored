using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WhoScored.Models.Models
{
    public class LeagueTable
    {
        public int Id { get; set; }

        [Required]
        public int LeagueId { get; set; }

        public virtual League League { get; set; }

        public int Season { get; set; }

        public ICollection<TeamStatistic> TeamStatistics { get; set; }
    }
}
