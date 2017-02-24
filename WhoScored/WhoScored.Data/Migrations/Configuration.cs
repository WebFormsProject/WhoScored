using WhoScored.Models;
using WhoScored.Models.Models;

namespace WhoScored.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<WhoScored.Data.WhoScoredContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WhoScored.Data.WhoScoredContext context)
        {
        }
    }
}
