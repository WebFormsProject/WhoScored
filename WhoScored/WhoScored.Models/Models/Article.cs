using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WhoScored.Models.Models
{
    public class Article
    {
        private ICollection<Comment> comments;

        public Article()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        public string Context { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public int Likes { get; set; }

        public string ImagePath { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsApproved { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}