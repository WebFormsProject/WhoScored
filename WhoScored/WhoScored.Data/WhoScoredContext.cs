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
    }
}