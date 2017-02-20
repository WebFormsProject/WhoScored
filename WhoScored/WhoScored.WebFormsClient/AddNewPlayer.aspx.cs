using System;
using System.Collections.Generic;
using System.Web.ModelBinding;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhoScored.Models.Models;
using WhoScored.MVP.Models;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;

namespace WhoScored.WebFormsClient
{
    [PresenterBinding(typeof(AddFootballPlayerPresenter))]
    public partial class AddNewPlayer : MvpPage<AddFootballPlayerViewModel>, IAddFootballPlayerView
    {
        public event EventHandler OnGetAllPlayers;
        public event EventHandler OnGetAllCoutries;
        public event EventHandler OnGetAllTeams;
        public event EventHandler<IdEventArgs> OnUpdateFootballPlayer;

        public IEnumerable<FootballPlayer> GetFootballPlayers()
        {
            this.OnGetAllPlayers?.Invoke(this, null);
            return this.Model.FootballPlayers;
        } 

        public IEnumerable<Country> GetCountries()
        {
            this.OnGetAllCoutries?.Invoke(this, null);
            return this.Model.Countries;
        }

        public IEnumerable<Models.Models.Team> GetTeams()
        {
            this.OnGetAllTeams?.Invoke(this, null);
            return this.Model.Teams;
        }

        public void UpdateFootballPlayer(int id)
        {
            this.OnUpdateFootballPlayer?.Invoke(this, new IdEventArgs(id));
        }
    }
}