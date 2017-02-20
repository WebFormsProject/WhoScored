using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhoScored.Models.Models;
using WhoScored.MVP.Models;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;

namespace WhoScored.WebFormsClient
{
    [PresenterBinding(typeof(AddFootballPlayerPresenter))]
    public partial class AddNewPlayer : MvpPage<AddFootballPlayerViewModel>, IAddFootballPlayerView
    {
        public event EventHandler OnGetAllPlayers;

        public IEnumerable<FootballPlayer> GetFootballPlayers()
        {
            this.OnGetAllPlayers?.Invoke(this, null);
            return this.Model.FootballPlayers;
        } 

        public IEnumerable<string> GetCountries()
        {
            return new List<string> {"Spain", "England", "Bulgaria"};
        }
    }
}