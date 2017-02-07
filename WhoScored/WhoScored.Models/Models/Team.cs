using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WhoScored.Models.Models
{
    public class Team
    {
        private ICollection<FootballPlayer> footballPlayers; 
        private ICollection<Title> titles;

        public Team()
        {
            this.FootballPlayers = new HashSet<FootballPlayer>();
            this.Titles = new HashSet<Title>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string EmblemImagePath { get; set; }

        public virtual ICollection<FootballPlayer> FootballPlayers
        {
            get { return this.footballPlayers; }
            set { this.footballPlayers = value; }
        }

        public virtual ICollection<Title> Titles
        {
            get { return this.titles; }
            set { this.titles = value; }
        }
    }
}
