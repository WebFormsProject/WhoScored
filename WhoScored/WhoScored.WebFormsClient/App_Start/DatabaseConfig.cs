using System.Data.Entity;
using WhoScored.Data;

namespace WhoScored.WebFormsClient
{
    public class DatabaseConfig
    {
        public static void InitializeDatabase()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WhoScoredContext, WhoScored.Data.Migrations.Configuration>());
            WhoScoredContext.Create().InitializeDb();
        }
    }
}