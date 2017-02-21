using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
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

        protected void CreateNewPlayer(object sender, EventArgs e)
        {
            string filePath = "";

            if (this.AvatarFileUpload.HasFile)
            {
                string extension = Path.GetExtension(this.AvatarFileUpload.PostedFile.FileName);
                filePath = "/photos/Players/" + this.NewPlayerFirstName.Text + this.NewPlayerLastName.Text + extension;
                this.AvatarFileUpload.SaveAs(Server.MapPath(filePath));
            }

            string firstName = Server.HtmlEncode(this.NewPlayerFirstName.Text);
            string lastName = Server.HtmlEncode(this.NewPlayerLastName.Text);
            int shirtNumber = int.Parse(this.NewPlayerShirtNumber.Text);
            int height = int.Parse(this.NewPlayerHeight.Text);
            int weight = int.Parse(this.NewPlayerWeight.Text);
            string position = this.PositionDropdown.SelectedValue;
            int teamId = int.Parse(this.SelectCurrentTeamDropdownNewPlayer.SelectedValue);
            int countryId = int.Parse(this.SelectCountryDropdownNewPlayer.SelectedValue);
            DateTime birthDate = DateTime.Parse(this.BirthDateNewPlayer.Text);

            this.OnAddFootballPlayer?.Invoke(this, new AddPlayerEventArgs(
                firstName, lastName, filePath, position,
                height, weight, shirtNumber, countryId, teamId, birthDate));
        }
    }
}