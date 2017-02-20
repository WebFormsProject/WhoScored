using System.ComponentModel.DataAnnotations;

namespace WhoScored.Models.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
