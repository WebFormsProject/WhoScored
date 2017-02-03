using System;
using System.ComponentModel.DataAnnotations;

namespace WhoScored.Models.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Context { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}