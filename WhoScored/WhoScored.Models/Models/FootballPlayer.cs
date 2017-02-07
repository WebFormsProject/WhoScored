using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhoScored.Models.Models
{
    public class FootballPlayer
    {
        private ICollection<Team> previousTeams;

        public FootballPlayer()
        {
            this.PreviousTeams = new HashSet<Team>();
        }

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        [Required]
        [ForeignKey("CurrentTeam")]
        public int CurrentTeamId { get; set; }

        public virtual Team CurrentTeam { get; set; }

        public virtual ICollection<Team> PreviousTeams
        {
            get { return this.previousTeams; }
            set { this.previousTeams = value; }
        }
    }
}
