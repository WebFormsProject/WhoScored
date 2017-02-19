using System;
using System.Collections.Generic;
using System.Web.Services;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhoScored.Models.Models;
using WhoScored.MVP.Models;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;

namespace WhoScored.WebFormsClient
{
    [PresenterBinding(typeof(ScoresPresenter))]
    public partial class Scores : MvpPage<ScoresViewModel>, IScoresView
    {
        public event EventHandler OnGetLeagues;
        public event EventHandler<GameNameEventArgs> OnGetGameByLeague;
        public event EventHandler<IdEventArgs> OnGetGameById;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IEnumerable<League> GetLeagues()
        {
            this.OnGetLeagues?.Invoke(this, null);
            var models = this.Model.Leagues;
            return models;
        }

        public IEnumerable<Game> GetGamesByLeague(League league)
        {
            this.OnGetGameByLeague?.Invoke(this, new GameNameEventArgs(league));

            return this.Model.GamesByLeague;
        }

        [WebMethod]
        public static object GetGameDetails(string id, string homeTeam, string awayTeam, string homeScorers, string awayScorers)
        {
            string homeScorersResult = homeScorers;
            string awayScorersResult = awayScorers;

            if (string.IsNullOrEmpty(homeScorers))
            {
                homeScorersResult = "No goal scorers";
            }

            if (string.IsNullOrEmpty(awayScorers))
            {
                awayScorersResult = "No goal scorers";
            }

            return new
            {
                HomeTeam = homeTeam,
                AwayTeam = awayTeam,
                HomeTeamScorers = homeScorersResult,
                AwayTeamScorers = awayScorersResult
            };
        }
    }
}