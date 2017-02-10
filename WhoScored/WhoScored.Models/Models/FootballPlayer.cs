using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WhoScored.Models.Models.Enums;

namespace WhoScored.Models.Models
{
    public class FootballPlayer
    {
        private ICollection<Team> previousTeams;
        private ICollection<Game> gamesScored; 

        public FootballPlayer()
        {
            this.previousTeams = new HashSet<Team>();
            this.gamesScored = new HashSet<Game>();
        }

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string ImagePath { get; set; }

        public PlayerPositionType Position { get; set; }

        public int ShirtNumber { get; set; }

        public DateTime? BirthDate { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public int CurrentTeamId { get; set; }

        public virtual Team CurrentTeam { get; set; }

        public virtual ICollection<Team> PreviousTeams
        {
            get { return this.previousTeams; }
            set { this.previousTeams = value; }
        }

        public virtual ICollection<Game> GamesScored
        {
            get { return this.gamesScored; }
            set { this.gamesScored = value; }
        }
    }
}
