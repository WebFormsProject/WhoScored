using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WhoScored.Models.Models
{
    public class TrollPhoto
    {
        private ICollection<Comment> comments; 

        public TrollPhoto()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public string PhotoPath { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public int Likes { get; set; }

        public bool IsDeleted { get; set; }
    }
}
