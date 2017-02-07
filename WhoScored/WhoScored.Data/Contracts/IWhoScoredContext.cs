using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WhoScored.Models.Models;

namespace WhoScored.Data.Contracts
{
    public interface IWhoScoredContext
    {
        IDbSet<Article> Articles
        {
            get; set;
        }

        IDbSet<Category> Categories
        {
            get; set;
        }

        IDbSet<Comment> Comments
        {
            get; set;
        }

        IDbSet<User> Users
        {
            get; set;
        }

        IDbSet<FootballPlayer> FootballPlayers
        {
            get; set;
        }

        IDbSet<Team> Teams
        {
            get; set;
        }

        IDbSet<Title> Titles
        {
            get; set;
        }

        IDbSet<TrollPhoto> TrollPhotos
        {
            get; set;
        }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void Create();

        void SaveChanges();
    }
}
