using System.Data.Entity;
using System.Linq;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;

namespace WhoScored.Data
{
    public class WhoScoredContext : DbContext, IWhoScoredContext
    {
        public WhoScoredContext()
            : base("WhoScored")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<WhoScoredContext>());
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

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public void Create()
        {
            this.Users.Count();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
