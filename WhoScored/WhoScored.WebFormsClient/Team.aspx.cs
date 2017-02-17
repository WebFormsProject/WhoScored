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
    [PresenterBinding(typeof(TeamPresenter))]
    public partial class Team : MvpPage<TeamViewModel>, ITeamView
    {
        public event EventHandler<TeamEventArgs> OnGetTeam;

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.TeamFormView = this.Model.Team;
        }

        public WhoScored.Models.Models.Team FormViewTeam_GetData()
        {
            string queryParam = this.Request.QueryString["id"];
            int id = int.Parse(queryParam);
            this.OnGetTeam?.Invoke(this, new TeamEventArgs(id));

            return this.Model.Team;
        }

        public IEnumerable<FootballPlayer> GetCurrentPlayers()
        {
            return this.FormViewTeam_GetData().CurrentFootballPlayers.ToList();
        } 
    }
}