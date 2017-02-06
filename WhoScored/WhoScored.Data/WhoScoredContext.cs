using System.Data.Entity;
using System.Linq;
using WhoScored.Models.Models;

namespace WhoScored.Data
{
    public class WhoScoredContext : DbContext
    {
        public WhoScoredContext()
            : base("WhoScored")
        {
        }

        public IDbSet<Article> Articles
        {
            get; set;
        }

        public IDbSet<Category> Categories
        {
            get; set;
        }

        public IDbSet<Comment> Comments
        {
            get; set;
        }

        public IDbSet<User> Users
        {
            get; set;
        }

        public IDbSet<FootballPlayer> FootballPlayers
        {
            get; set;
        }

        public IDbSet<Team> Teams
        {
            get; set;
        }

        public IDbSet<Title> Titles
        {
            get; set;
        }

        public IDbSet<TrollPhoto> TrollPhotos
        {
            get; set;
        }

        public void Create()
        {
            this.Users.Count();
        }
    }
}
