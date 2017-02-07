using System.ComponentModel.DataAnnotations;

namespace WhoScored.Models.Models
{
    public class TeamStatistic
    {
        public int Id { get; set; }

        [Required]
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        [Required]
        public int Position { get; set; }

        [Required]
        public int PlayedGames { get; set; }

        [Required]
        public int WonGames { get; set; }
        
        [Required]
        public int DrawGames { get; set; }

        [Required]
        public int LostGames { get; set; }

        [Required]
        public int GoalsFor { get; set; }

        [Required]
        public int GoalsAgainst { get; set; }

        [Required]
        public int GoalDifference { get; set; }

        [Required]
        public int Points { get; set; }
    }
}
