using System;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhoScored.WebFormsClient.Models;
using WhoScored.WebFormsClient.Presenters;
using WhoScored.WebFormsClient.Views;

namespace WhoScored.WebFormsClient
{
    [PresenterBinding(typeof(ScoresPresenter))]
    public partial class Scores : MvpPage<ScoresModelView>, IScoresView
    {
        public event EventHandler OnGetLatestScores;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.OnGetLatestScores?.Invoke(sender, null);

            var games = this.Model.Games.ToList();
        }

    }
}