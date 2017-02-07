using System.Data.Entity;
using WhoScored.Data;
using WhoScored.Data.Contracts;

namespace WhoScored.WebFormsClient.App_Start
{
    public class DatabaseConfig
    {
        public static void InitializeDatabase()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WhoScoredContext, Data.Migrations.Configuration>());
            IWhoScoredContext context = new WhoScoredContext();
            context.Create();
        }
    }
}