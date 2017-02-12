using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WhoScored.Models.Models
{
    public class Coach
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string ImagePath { get; set; }

        public DateTime BirthDate { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
