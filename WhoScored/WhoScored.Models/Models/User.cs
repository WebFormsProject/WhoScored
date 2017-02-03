using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhoScored.Models.Models
{
    public class User
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public string AvatarPath { get; set; }

        public string[] Roles { get; set; }
    }
}
