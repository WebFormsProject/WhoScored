using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WhoScored.Models.Models;

namespace WhoScored.Data.Contracts
{
    public interface IWhoScoredContext
    {
        IDbSet<Article> Articles { get; }

        IDbSet<Category> Categories { get; }

        IDbSet<Comment> Comments { get; }

        IDbSet<User> Users { get; }

        IDbSet<FootballPlayer> FootballPlayers { get; }

        IDbSet<Team> Teams { get; }

        IDbSet<Title> Titles { get; }

        IDbSet<TrollPhoto> TrollPhotos { get; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void InitializeDb();

        void SaveChanges();
    }
}
