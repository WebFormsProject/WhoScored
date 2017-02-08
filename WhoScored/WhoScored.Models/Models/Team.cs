using System.Collections.Generic;

namespace WhoScored.Models.Models
{
    public class Team
    {
        private ICollection<FootballPlayer> currentFootballPlayers; 
        private ICollection<FootballPlayer> previousFootballPlayers;
        private ICollection<Title> titles;

        public Team()
        {
            this.currentFootballPlayers = new HashSet<FootballPlayer>();
            this.previousFootballPlayers = new HashSet<FootballPlayer>();
            this.titles = new HashSet<Title>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string EmblemImagePath { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<FootballPlayer> CurrentFootballPlayers
        {
            get { return this.currentFootballPlayers; }
            set { this.currentFootballPlayers = value; }
        }

        public virtual ICollection<FootballPlayer> PreviousFootballPlayers
        {
            get { return this.previousFootballPlayers; }
            set { this.previousFootballPlayers = value; }
        }


        public virtual ICollection<Title> Titles
        {
            get { return this.titles; }
            set { this.titles = value; }
        }
    }
}
