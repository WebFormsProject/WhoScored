using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhoScored.Models.Models;
using WhoScored.WebFormsClient.Models;
using WhoScored.WebFormsClient.Presenters;
using WhoScored.WebFormsClient.Views;

namespace WhoScored.WebFormsClient
{
    [PresenterBinding(typeof(LeaguePresenter))]
    public partial class Leagues : MvpPage<LeaguesViewModel>, ILeaguesView
    {
        public event EventHandler GetLeagues;
        
        public IEnumerable<League> ListViewLeagues_GetData()
        {
            this.GetLeagues?.Invoke(this, null);

            return this.Model.Leagues;
        }
    }
}