using System.ComponentModel.DataAnnotations;

namespace WhoScored.Models.Models
{
    public class League
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public string LeaugeLogo { get; set; }
    }
}
