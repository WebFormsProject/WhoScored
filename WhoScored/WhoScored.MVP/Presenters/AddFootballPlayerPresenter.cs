using System;
using Bytes2you.Validation;
using WebFormsMvp;
using WhoScored.Models.Models;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Views;
using WhoScored.Services.Contracts;

namespace WhoScored.MVP.Presenters
{
    public class AddFootballPlayerPresenter : Presenter<IAddFootballPlayerView>
    {
        private readonly IFootballPlayerService footballPlayerService;
        private readonly ICountryService countryService;
        private readonly ITeamService teamService;

        public AddFootballPlayerPresenter(
            IAddFootballPlayerView view,
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
