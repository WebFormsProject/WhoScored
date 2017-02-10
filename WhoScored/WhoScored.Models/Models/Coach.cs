using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WhoScored.Models.Models
{
    public class Coach
    {
        //private ICollection<Team> previousTeams;

        public Coach()
        {
            //this.previousTeams = new HashSet<Team>();
        }

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string ImagePath { get; set; }

        public DateTime BirthDate { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        //public int CurrentTeamId { get; set; }

        //public virtual Team CurrentTeam { get; set; }

        //public virtual ICollection<Team> PreviousTeams
        //{
        //    get { return this.previousTeams; }
        //    set { this.previousTeams = value; }
        //}
    }
}
