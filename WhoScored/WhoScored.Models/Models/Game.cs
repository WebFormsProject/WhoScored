using System;
using System.Collections.Generic;

namespace WhoScored.Models.Models
{
    public class Game
    {
        private ICollection<FootballPlayer> goalScorers; 

        public Game()
        {
            this.goalScorers = new HashSet<FootballPlayer>();
        }

        public int Id { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public int HomeTeamId { get; set; }

        public virtual Team HomeTeam { get; set; }
        
        public int AwayTeamId { get; set; }

        public virtual Team AwayTeam { get; set; }

        public int LeagueId { get; set; }

        public virtual League League { get; set; }

        public DateTime GameDate { get; set; }

        public virtual ICollection<FootballPlayer> GoalScorers
        {
            get { return this.goalScorers; }
            set { this.goalScorers = value; }
        }
    }
}