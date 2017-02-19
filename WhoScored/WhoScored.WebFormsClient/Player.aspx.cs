using System;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhoScored.Models.Models;
using WhoScored.MVP.Models;
using WhoScored.MVP.Models.CustomEvents;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;

namespace WhoScored.WebFormsClient
{
    [PresenterBinding(typeof(FootballPlayerPresenter))]
    public partial class Player : MvpPage<FootballPlayerViewModel>, IFootballPlayerView
    {
        public event EventHandler<IdEventArgs> OnGetFootballPlayerById;

        public FootballPlayer FormViewPlayer_GetData()
        {
            string queryId = this.Request.QueryString["id"];
            int id = int.Parse(queryId);

            this.OnGetFootballPlayerById?.Invoke(this, new IdEventArgs(id));

            return this.Model.FootballPlayer;
        }
    }
}