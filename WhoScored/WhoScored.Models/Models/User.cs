using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WhoScored.Models.Models
{
    public class User : IdentityUser
    {
        private ICollection<TrollPhoto> pinnedTrollPhotos;
        private ICollection<Article> pinnedArticles;
         
        public User()
        {
            this.PinnedTrollPhotos = new HashSet<TrollPhoto>();
            this.PinnedArticles = new HashSet<Article>();
        }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        public string AvatarPath { get; set; }

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

        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}
