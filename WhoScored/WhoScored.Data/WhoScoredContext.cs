using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WhoScored.Data.Contracts;
using WhoScored.Models;
using WhoScored.Models.Models;
using WhoScored.Models.Models.Enums;

namespace WhoScored.Data
{
    public class WhoScoredContext : IdentityDbContext<User>, IWhoScoredContext
    {
        public WhoScoredContext()
            : base("WhoScored")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<WhoScoredContext>());
        }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Coach> Coaches { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<FootballPlayer> FootballPlayers { get; set; }

        public IDbSet<Game> Games { get; set; }

        public IDbSet<League> Leagues { get; set; }

        public IDbSet<LeagueTable> LeagueTables { get; set; }

        public IDbSet<Team> Teams { get; set; }

        public IDbSet<TeamStatistic> TeamStatistics { get; set; }

        public IDbSet<Title> Titles { get; set; }

        public IDbSet<TrollPhoto> TrollPhotos { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public static WhoScoredContext Create()
        {
            return new WhoScoredContext();
        }

        public void InitializeDb()
        {
            //this.InitializeIdentity();
            //this.SeedCategories();
            //this.SaveChanges();

            //this.SeedCountries();
            //this.SaveChanges();

            //this.SeedCoaches();
            //this.SaveChanges();

            ////this.SeedTeams();
            ////this.SaveChanges();

            //this.SeedFootballPlayers();
            //this.SaveChanges();

            //this.SeedLeagues();
            //this.SaveChanges();

            //this.SeedGames();
            //this.SaveChanges();

            //this.SeedStatisitcs();
            //this.SeedTrollPhotos();
            //this.SaveChanges();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<User>().ToTable("AspNetUsers");
            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("AspNetUserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("AspNetUserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("AspNetUserClaims");

            base.OnModelCreating(modelBuilder);

            this.MapTeamTable(modelBuilder);
            this.MapFootballPlayerTable(modelBuilder);
            this.MapGameTable(modelBuilder);
        }

        private void MapTeamTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
           .HasMany(x => x.PreviousFootballPlayers)
           .WithMany(x => x.PreviousTeams)
           .Map(m =>
           {
               m.MapLeftKey("Team_Id");
               m.MapRightKey("FootballPlayer_Id");
               m.ToTable("TeamsFootballPlayers");
           });
        }

        public void InitializeIdentity()
        {
            if (!this.Users.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(this);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var userStore = new UserStore<User>(this);
                var userManager = new UserManager<User>(userStore);

                // Add missing roles
                var role = roleManager.FindByName("Admin");
                if (role == null)
                {
                    role = new IdentityRole("Admin");
                    roleManager.Create(role);
                }

                // Create test users
                var user = userManager.FindByName("admin");
                if (user == null)
                {
                    var newUser = new User()
                    {
                        UserName = "admin",
                        FirstName = "Admin",
                        LastName = "User",
                        Email = "xxx@xxx.net",
                        PhoneNumber = "123456"
                    };

                    userManager.Create(newUser, "unicorn");
                    userManager.SetLockoutEnabled(newUser.Id, false);
                    userManager.AddToRole(newUser.Id, "Admin");
                }
            }
        }

        private void MapGameTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
               .HasMany(x => x.GoalScorers)
               .WithMany(x => x.GamesScored)
               .Map(m =>
               {
                   m.MapLeftKey("GameId");
                   m.MapRightKey("FootballPlayerId");
                   m.ToTable("GameGoalScorersFootballPlayers");
               });
        }

        private void MapFootballPlayerTable(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FootballPlayer>()
               .HasRequired(x => x.CurrentTeam)
               .WithMany(x => x.CurrentFootballPlayers);
        }

        #region Seed Data
        private void SeedStatisitcs()
        {
            var realMadrid = this.Teams.SingleOrDefault(x => x.Name == "Real Madrid");
            var arsenal = this.Teams.SingleOrDefault(x => x.Name == "Arsenal");
            var barcelona = this.Teams.SingleOrDefault(x => x.Name == "Barcelona");
            var bayern = this.Teams.SingleOrDefault(x => x.Name == "Bayern Munich");
            var chelsea = this.Teams.SingleOrDefault(x => x.Name == "Chelsea");

            var rmSt = new TeamStatistic { Team = realMadrid };
            var barcelonaStatistics = new TeamStatistic { Team = barcelona };
            var arsenalStatistics = new TeamStatistic { Team = arsenal };
            var chelseaStatistics = new TeamStatistic { Team = chelsea };
            this.TeamStatistics.Add(rmSt);
            this.TeamStatistics.Add(barcelonaStatistics);
            this.TeamStatistics.Add(arsenalStatistics);
            this.TeamStatistics.Add(chelseaStatistics);
            this.TeamStatistics.Add(new TeamStatistic { Team = bayern });

            this.SaveChanges();

            var premier = this.Leagues.SingleOrDefault(x => x.Name == "Premier League");
            var laLiga = this.Leagues.SingleOrDefault(x => x.Name == "La Liga");
            var bundesliga = this.Leagues.SingleOrDefault(x => x.Name == "Bundesliga");

            this.LeagueTables.Add(new LeagueTable()
            {
                League = premier,
                TeamStatistics = new HashSet<TeamStatistic>() { arsenalStatistics, chelseaStatistics }
            });

            this.LeagueTables.Add(new LeagueTable()
            {
                League = laLiga,
                TeamStatistics = new HashSet<TeamStatistic>() { rmSt, barcelonaStatistics }
            });

            this.SaveChanges();

        }

        private void SeedCategories()
        {
            this.Categories.AddOrUpdate(x => x.Name,
                new Category()
                {
                    Name = "Troll Photo"
                });
        }

        private void SeedCountries()
        {
            this.Countries.AddOrUpdate(x => x.Name,
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

        private void SeedFootballPlayers()
        {
            var spain = this.Countries.SingleOrDefault(x => x.Name == "Spain");
            var germany = this.Countries.SingleOrDefault(x => x.Name == "Germany");
            var portugal = this.Countries.SingleOrDefault(x => x.Name == "Portugal");

            var realMadrid = this.Teams.SingleOrDefault(x => x.Name == "Real Madrid");
            var arsenal = this.Teams.SingleOrDefault(x => x.Name == "Arsenal");
            var barcelona = this.Teams.SingleOrDefault(x => x.Name == "Barcelona");
            var bayern = this.Teams.SingleOrDefault(x => x.Name == "Bayern Munich");

            this.FootballPlayers.AddOrUpdate(new FootballPlayer()
            {
                FirstName = "Sergio",
                LastName = "Ramos",
                CurrentTeam = realMadrid,
                Country = spain,
                Position = PlayerPositionType.Defender,
                PreviousTeams = new HashSet<Team>() { arsenal, bayern },
                ImagePath = "/photos/Players/sergio-ramos.jpg"
            },
            new FootballPlayer()
            {
                FirstName = "Mesut",
                LastName = "Ozil",
                CurrentTeam = arsenal,
                Country = germany,
                Position = PlayerPositionType.Midfielder,
                PreviousTeams = new HashSet<Team>() { realMadrid },
                ImagePath = "/photos/Players/mesut-ozil.png"
            },
            new FootballPlayer()
            {
                FirstName = "Manuel",
                LastName = "Neuer",
                CurrentTeam = bayern,
                Country = germany,
                Position = PlayerPositionType.Goalkeeper
            },
            new FootballPlayer()
            {
                FirstName = "Cristiano",
                LastName = "Ronaldo",
                CurrentTeam = realMadrid,
                Country = portugal,
                Position = PlayerPositionType.Forward,
                ImagePath = "/photos/Players/cristiano-ronaldo.jpg"
            },
            new FootballPlayer()
            {
                FirstName = "Gerard",
                LastName = "Pique",
                CurrentTeam = barcelona,
                Country = spain,
                Position = PlayerPositionType.Defender
            });
        }

        private void SeedCoaches()
        {
            var france = this.Countries.FirstOrDefault(x => x.Name == "France");

            this.Coaches.AddOrUpdate(new Coach()
            {
                FirstName = "Zinedine",
                LastName = "Zidane",
                Country = france,
                BirthDate = DateTime.Now
            },
            new Coach()
            {
                FirstName = "Arsene",
                LastName = "Wenger",
                Country = france,
                BirthDate = DateTime.Now
            },
            new Coach()
            {
                FirstName = "Carlo",
                LastName = "Ancelotti",
                Country = france,
                BirthDate = DateTime.Now
            },
            new Coach()
            {
                FirstName = "Leonardo",
                LastName = "Jardim",
                Country = france,
                BirthDate = DateTime.Now
            },
            new Coach()
            {
                FirstName = "Luis",
                LastName = "Enrique",
                Country = france,
                BirthDate = DateTime.Now
            },
            new Coach()
            {
                FirstName = "Jose",
                LastName = "Mourinho",
                Country = france,
                BirthDate = DateTime.Now
            },
            new Coach()
            {
                FirstName = "Nuno",
                LastName = "Santo",
                Country = france,
                BirthDate = DateTime.Now
            });
        }

        private void SeedTeams()
        {
            var spain = this.Countries.SingleOrDefault(x => x.Name == "Spain");
            var england = this.Countries.SingleOrDefault(x => x.Name == "England");
            var germany = this.Countries.SingleOrDefault(x => x.Name == "Germany");
            var france = this.Countries.SingleOrDefault(x => x.Name == "France");
            var portugal = this.Countries.SingleOrDefault(x => x.Name == "Portugal");

            var zidane = this.Coaches.FirstOrDefault(x => x.FirstName == "Zinedine");
            var arsene = this.Coaches.FirstOrDefault(x => x.FirstName == "Arsene");
            var jose = this.Coaches.FirstOrDefault(x => x.FirstName == "Jose");
            var carlo = this.Coaches.FirstOrDefault(x => x.FirstName == "Carlo");
            var leonardo = this.Coaches.FirstOrDefault(x => x.FirstName == "Leonardo");
            var nuno = this.Coaches.FirstOrDefault(x => x.FirstName == "Nuno");
            var luis = this.Coaches.FirstOrDefault(x => x.FirstName == "Luis");

            this.Teams.AddOrUpdate(x => x.Name,
                new Team()
                {
                    Name = "Real Madrid",
                    CountryId = spain.Id,
                    Coach = zidane,
                    EmblemImagePath = "/photos/Teams/real-madrid-la-liga.jpg"
                },
                new Team()
                {
                    Name = "Arsenal",
                    CountryId = england.Id,
                    Coach = arsene,
                    EmblemImagePath = "/photos/Teams/arsenal-premier-league.png"
                },
                new Team()
                {
                    Name = "Bayern Munich",
                    CountryId = germany.Id,
                    Coach = carlo
                },
                new Team()
                {
                    Name = "Monaco",
                    CountryId = france.Id,
                    Coach = leonardo
                },
                new Team()
                {
                    Name = "FC Porto",
                    CountryId = portugal.Id,
                    Coach = nuno

                }, new Team()
                {
                    Name = "Chelsea",
                    CountryId = england.Id,
                    Coach = jose
                },
                new Team()
                {
                    Name = "Barcelona",
                    CountryId = spain.Id,
                    Coach = luis
                });
        }

        private void SeedLeagues()
        {
            this.Leagues.AddOrUpdate(x => x.Name,
                new League() { Name = "Premier League", CountryId = 2, LeaugeLogo = "/photos/Leagues/premier-league.png" },
                new League() { Name = "La Liga", CountryId = 1, LeaugeLogo = "/photos/Leagues/la-liga.png" },
                new League() { Name = "Bundesliga", CountryId = 4, LeaugeLogo = "/photos/Leagues/bundesliga.png" });
        }

        private void SeedGames()
        {

            var realMadrid = this.Teams.SingleOrDefault(x => x.Name == "Real Madrid");
            var arsenal = this.Teams.SingleOrDefault(x => x.Name == "Arsenal");
            var chelsea = this.Teams.SingleOrDefault(x => x.Name == "Chelsea");
            var barcelona = this.Teams.SingleOrDefault(x => x.Name == "Barcelona");

            var ronaldo = this.FootballPlayers.SingleOrDefault(x => x.LastName == "Ronaldo");
            var pique = this.FootballPlayers.SingleOrDefault(x => x.LastName == "Pique");
            var ozil = this.FootballPlayers.SingleOrDefault(x => x.LastName == "Ozil");

            var premier = this.Leagues.SingleOrDefault(x => x.Name == "Premier League");
            var laLiga = this.Leagues.SingleOrDefault(x => x.Name == "La Liga");
            var bundesliga = this.Leagues.SingleOrDefault(x => x.Name == "Bundesliga");

            this.Games.AddOrUpdate(
                new Game()
                {
                    AwayTeam = chelsea,
                    HomeTeam = arsenal,
                    AwayTeamGoals = 0,
                    HomeTeamGoals = 3,
                    GameDate = DateTime.Now,
                    League = premier,
                    GoalScorers = new HashSet<FootballPlayer>() { ozil }
                },
                    new Game()
                    {
                        AwayTeam = barcelona,
                        HomeTeam = realMadrid,
                        AwayTeamGoals = 1,
                        HomeTeamGoals = 4,
                        GameDate = DateTime.Now,
                        League = laLiga,
                        GoalScorers = new HashSet<FootballPlayer>() { ronaldo, pique }
                    });
        }

        private void SeedTrollPhotos()
        {
            this.TrollPhotos.Add(
                new TrollPhoto()
                {
                    PhotoPath = "/photos/TrollPhotos/image1.jpg"
                });
            this.TrollPhotos.Add(
                new TrollPhoto()
                {
                    PhotoPath = "/photos/TrollPhotos/image2.jpg"
                });
            this.TrollPhotos.Add(
                new TrollPhoto()
                {
                    PhotoPath = "/photos/TrollPhotos/image3.jpg"
                });
            this.TrollPhotos.Add(
                new TrollPhoto()
                {
                    PhotoPath = "/photos/TrollPhotos/image4.jpg"
                });
            this.TrollPhotos.Add(
                new TrollPhoto()
                {
                    PhotoPath = "/photos/TrollPhotos/image5.jpg"
                });
            this.TrollPhotos.Add(
                new TrollPhoto()
                {
                    PhotoPath = "/photos/TrollPhotos/image6.jpg"
                });
        }
        #endregion
    }
}