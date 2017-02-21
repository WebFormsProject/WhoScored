using System;
using System.Collections.Generic;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhoScored.Models.Models;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Admin;

namespace WhoScored.WebFormsClient
{
    [PresenterBinding(typeof(ManageFootballPlayersPresenter))]
    public partial class ManagePlayers : MvpPage<ManageFootballPlayersViewModel>, IManageFootballPlayersView
    {
        public event EventHandler OnGetAllPlayers;
        public event EventHandler OnGetAllCoutries;
        public event EventHandler OnGetAllTeams;
        public event EventHandler<IdEventArgs> OnUpdateFootballPlayer;
        public event EventHandler<IdEventArgs> OnDeleteFootballPlayer;
        public event EventHandler<AddPlayerEventArgs> OnAddFootballPlayer;

        public IEnumerable<FootballPlayer> GetFootballPlayers()
        {
            this.OnGetAllPlayers?.Invoke(this, null);
            return this.Model.FootballPlayers;
        } 

        public IEnumerable<Country> GetCountries()
        {
            this.OnGetAllCoutries?.Invoke(this, null);
            return this.Model.Countries.ToList();
        }

        public IEnumerable<Models.Models.Team> GetTeams()
        {
            this.OnGetAllTeams?.Invoke(this, null);
            return this.Model.Teams.ToList();
        }

        public void UpdateFootballPlayer(int id)
        {
            this.OnUpdateFootballPlayer?.Invoke(this, new IdEventArgs(id));
        }

        public void DeleteFootballPlayer(int id)
        {
            this.OnDeleteFootballPlayer?.Invoke(this, new IdEventArgs(id));
        }

        public void InsertFootballPlayer()
        {
            // this.OnAddFootballPlayer?.Invoke(this, new AddPlayerEventArgs());
        }
    }
}