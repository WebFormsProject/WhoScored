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



        private void SeedCountries(WhoScoredContext context)
        {
            context.Countries.AddOrUpdate(x => x.Name,
                new Country()
                {
                    Name = "Spain"
                },
                new Country()
                {
                    Name = "England"
                },
                new Country()
                {
                    Name = "France"
                },
                new Country()
                {
                    Name = "Germany"
                },
                new Country()
                {
                    Name = "Portugal"
                });
        }

        private void SeedFootballPlayers(WhoScoredContext context)
        {

        }

        private void SeedTeams(WhoScoredContext context)
        {
            var spain = context.Countries.SingleOrDefault(x => x.Name == "Spain");
            var england = context.Countries.SingleOrDefault(x => x.Name == "England");
            var germany = context.Countries.SingleOrDefault(x => x.Name == "Germany");
            var france = context.Countries.SingleOrDefault(x => x.Name == "France");
            var portugal = context.Countries.SingleOrDefault(x => x.Name == "Portugal");

            context.Teams.AddOrUpdate(x => x.Name,
                new Team()
                {
                    Name = "Real Madrid",
                    CountryId = spain.Id
                },
                new Team()
                {
                    Name = "Arsenal",
                    CountryId = england.Id
                },
                new Team()
                {
                    Name = "Bayern Munich",
                    CountryId = germany.Id
                },
                new Team()
                {
                    Name = "Monaco",
                    CountryId = france.Id
                },
                new Team()
                {
                    Name = "FC Porto",
                    CountryId = portugal.Id

                }, new Team()
                {
                    Name = "Chelsea",
                    CountryId = england.Id
                });
        }
    }
}
