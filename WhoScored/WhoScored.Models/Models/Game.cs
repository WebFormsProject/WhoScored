using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoScored.Models.Models
{
    public class Game
    {
        private ICollection<FootballPlayer> homeTeamScorers; 
        private ICollection<FootballPlayer> awayTeamScorers;

        public Game()
        {
            this.HomeTeamScorers = new HashSet<FootballPlayer>();
            this.AwayTeamScorers = new HashSet<FootballPlayer>();
        }

        public int Id { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        [ForeignKey("HomeTeam")]
        public int HomeTeamId { get; set; }

        public virtual Team HomeTeam { get; set; }

        [ForeignKey("AwayTeam")]
        public int AwayTeamId { get; set; }

        public virtual Team AwayTeam { get; set; }

        public virtual ICollection<FootballPlayer> HomeTeamScorers
        {
            get { return this.homeTeamScorers; }
            set { this.homeTeamScorers = value; }
        }

        public virtual ICollection<FootballPlayer> AwayTeamScorers
        {
            get { return this.awayTeamScorers; }
            set { this.awayTeamScorers = value; }
        }
    }
}