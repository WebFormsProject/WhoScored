using System;
using System.Collections.Generic;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhoScored.Models.Models;
using WhoScored.MVP.Admin;

namespace WhoScored.WebFormsClient.Admin
{
    [PresenterBinding(typeof(ManageLeaguePresenter))]
    public partial class ManageLeagues : MvpPage<ManageLeagueViewModel> , IManageLeagueView 
    {
        public event EventHandler OnGetAllLeagues;
        public event EventHandler OnGetAllCountries;
        public event EventHandler OnAddLeague;

        public IEnumerable<League> GetAllLeagues()
        {
            this.OnGetAllLeagues?.Invoke(this, null);
            return this.Model.Leagues;
        }

        public IEnumerable<Country> GetCountries()
        {
            this.OnGetAllCountries?.Invoke(this, null);
            return this.Model.Countries.ToList();
        }

        public void AddLeague()
        {
            this.OnAddLeague?.Invoke(this, null);
        }

        public void UpdateLeague()
        {

        }

        public void DeleteLeague()
        {

        }
    }
}