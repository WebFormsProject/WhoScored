using System.ComponentModel.DataAnnotations;

namespace WhoScored.Models.Models
{
    public class TeamStatistic
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        public int Position { get; set; }

        public int PlayedGames { get; set; }

        public int WonGames { get; set; }
        
        public int DrawGames { get; set; }

        public int LostGames { get; set; }

        public int GoalsFor { get; set; }

        public int GoalsAgainst { get; set; }

        public int GoalDifference { get; set; }

        public int Points { get; set; }
    }
}
