using System;
using System.Collections.Generic;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhoScored.Models.Models;
using WhoScored.MVP.Models;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;

namespace WhoScored.WebFormsClient
{
    [PresenterBinding(typeof(LeaguePresenter))]
    public partial class Leagues : MvpPage<LeaguesViewModel>, ILeaguesView
    {
        public event EventHandler OnGetLeagues;
        
        public IEnumerable<League> ListViewLeagues_GetData()
        {
            this.OnGetLeagues?.Invoke(this, null);

            return this.Model.Leagues;
        }
    }
}