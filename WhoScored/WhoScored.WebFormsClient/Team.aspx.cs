﻿using System;
using System.Collections.Generic;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhoScored.Models.Models;
using WhoScored.MVP.Models;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;

namespace WhoScored.WebFormsClient
{
    [PresenterBinding(typeof(TeamPresenter))]
    public partial class Team : MvpPage<TeamViewModel>, ITeamView
    {
        public event EventHandler<WhoScored.MVP.Models.CustomEventArgs.IdEventArgs> OnGetTeam;

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.TeamFormView = this.Model.Team;
        }

        public WhoScored.Models.Models.Team FormViewTeam_GetData()
        {
            string queryParam = this.Request.QueryString["id"];
            int id = int.Parse(queryParam);
            this.OnGetTeam?.Invoke(this, new IdEventArgs(id));

            return this.Model.Team;
        }

        public IEnumerable<FootballPlayer> GetCurrentPlayers()
        {
            return this.FormViewTeam_GetData().CurrentFootballPlayers.ToList();
        } 
    }
}