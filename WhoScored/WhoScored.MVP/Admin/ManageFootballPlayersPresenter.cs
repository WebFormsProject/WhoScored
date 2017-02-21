using System;
using System.Web;
using Bytes2you.Validation;
using WebFormsMvp;
using WhoScored.Models.Models;
using WhoScored.MVP.Admin;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.Services.Contracts;

namespace WhoScored.MVP.Presenters
{
    public class ManageFootballPlayersPresenter : Presenter<IManageFootballPlayersView>
    {
        private const int MaxAvatarSizeInBytes = 10 * 1000 * 1000;

        private readonly IFootballPlayerService footballPlayerService;
        private readonly ICountryService countryService;
        private readonly ITeamService teamService;

        public ManageFootballPlayersPresenter(
            IManageFootballPlayersView view,
            IFootballPlayerService footballPlayerService,
            ICountryService countryService,
            ITeamService teamService)
            : base(view)
        {
            Guard.WhenArgument(footballPlayerService, "footballPlayerService").IsNull().Throw();
            Guard.WhenArgument(countryService, "countryService").IsNull().Throw();
            Guard.WhenArgument(teamService, "teamService").IsNull().Throw();

            this.footballPlayerService = footballPlayerService;
            this.countryService = countryService;
            this.teamService = teamService;

            this.View.OnGetAllPlayers += View_OnGetAllPlayers;
            this.View.OnGetAllCoutries += View_OnGetAllCoutries;
            this.View.OnGetAllTeams += View_OnGetAllTeams;
            this.View.OnUpdateFootballPlayer += View_OnUpdateFootballPlayer;
            this.View.OnDeleteFootballPlayer += View_OnDeleteFootballPlayer;
            this.View.OnAddFootballPlayer += View_OnAddFootballPlayer;
        }

        private void View_OnAddFootballPlayer(object sender, AddPlayerEventArgs e)
        {
            this.footballPlayerService.AddFootballPlayer(e.FirstName, e.LastName,
                e.ImagePath,
                e.Position,
                e.Height,
                e.Weight,
                e.ShirtNumber,
                e.CountryId,
                e.TeamId,
                e.BirthDate.Value);
        }

        private void View_OnUpdateFootballPlayer(object sender, IdEventArgs e)
        {
            FootballPlayer player = this.footballPlayerService.GetFootballPlayerById(e.Id);

            if (player == null)
            {
                // The item wasn't found
                this.View.ModelState.
                    AddModelError("", String.Format("Item with id {0} was not found", e.Id));
                return;
            }

            this.View.TryUpdateModel(player);
            if (this.View.ModelState.IsValid)
            {
                this.footballPlayerService.UpdateFootballPlayer(player);
            }
        }

        private void View_OnDeleteFootballPlayer(object sender, IdEventArgs e)
        {
            FootballPlayer player = this.footballPlayerService.GetFootballPlayerById(e.Id);

            this.footballPlayerService.DeleteFootballPlayer(player);
        }

        private void View_OnGetAllTeams(object sender, EventArgs eventArgs)
        {
            this.View.Model.Teams = this.teamService.GetAllTeams();
        }

        private void View_OnGetAllCoutries(object sender, EventArgs eventArgs)
        {
            this.View.Model.Countries = this.countryService.GetAllCountries();
        }

        private void View_OnGetAllPlayers(object sender, EventArgs eventArgs)
        {
            this.View.Model.FootballPlayers = this.footballPlayerService.GetAllFootballPlayers();
        }
    }
}
