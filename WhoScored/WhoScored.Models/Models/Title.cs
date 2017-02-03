using System;
using System.ComponentModel.DataAnnotations;

namespace WhoScored.Models.Models
{
    public class Title
    {
        public int Id { get; set; }

        [Required]
        public string TitleName { get; set; }

        // public TitleType TitleType { get; set; }

        public DateTime Year { get; set; }
    }
}