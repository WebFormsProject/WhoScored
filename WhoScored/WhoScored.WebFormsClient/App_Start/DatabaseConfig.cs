using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
//using WhoScored.Data;

namespace WhoScored.WebFormsClient.App_Start
{
    public class DatabaseConfig
    {
        public static void InitializeDatabase()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<WhoScoredContext, Data.Migrations.Configuration>());
            //var context = new WhoScoredContext();
            //context.Create();
        }
    }
}