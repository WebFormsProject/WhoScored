using System;
using System.Collections.Generic;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhoScored.Models.Models;
using WhoScored.WebFormsClient.Models;
using WhoScored.WebFormsClient.Models.CustomEvents;
using WhoScored.WebFormsClient.Presenters;
using WhoScored.WebFormsClient.Views;

namespace WhoScored.WebFormsClient
{
    [PresenterBinding(typeof(ScoresPresenter))]
    public partial class Scores : MvpPage<ScoresModelView>, IScoresView
    {
        public event EventHandler OnGetLeagues;
        public event EventHandler<GameNameEventArgs> OnGetGameByLeague;

        protected void Page_Load(object sender, EventArgs e)
        {
            //ScoresGridView.DataSource = this.Model.Games.ToList();
            //ScoresGridView.DataBind();
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
    }
}