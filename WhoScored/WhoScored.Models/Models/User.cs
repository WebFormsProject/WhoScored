using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhoScored.Models.Models
{
    public class User
    {
        private ICollection<TrollPhoto> pinnedTrollPhotos;
        private ICollection<Article> pinnedArticles;
         
        public User()
        {
            this.PinnedTrollPhotos = new HashSet<TrollPhoto>();
            this.PinnedArticles = new HashSet<Article>();
        }

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

        public virtual ICollection<TrollPhoto> PinnedTrollPhotos
        {
            get { return this.pinnedTrollPhotos; }
            set { this.pinnedTrollPhotos = value; }
        }

        public virtual ICollection<Article> PinnedArticles
        {
            get { return this.pinnedArticles; }
            set { this.pinnedArticles = value; }
        }
    }
}
