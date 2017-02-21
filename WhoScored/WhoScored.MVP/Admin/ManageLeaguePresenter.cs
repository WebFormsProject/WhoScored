using System;
using Bytes2you.Validation;
using WebFormsMvp;
using WhoScored.Models.Models;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.Services.Contracts;

namespace WhoScored.MVP.Admin
{
    public class ManageLeaguePresenter : Presenter<IManageLeagueView>
    {
        private readonly ILeagueService leagueService;
        private readonly ICountryService countryService;

        public ManageLeaguePresenter(
            IManageLeagueView view,
            ILeagueService leagueService,
            ICountryService countryService) 
            : base(view)
        {
            Guard.WhenArgument(leagueService, "leagueService").IsNull().Throw();
            Guard.WhenArgument(countryService, "countryService").IsNull().Throw();
            this.leagueService = leagueService;
            this.countryService = countryService;

            this.View.OnGetAllLeagues += View_OnGetAllLeagues;
            this.View.OnGetAllCountries += View_OnGetAllCountries;
            this.View.OnAddLeague += View_OnAddLeague;
            this.View.OnDeleteLeague += View_OnDeleteLeague;
            this.View.OnUpdateLeague += View_OnUpdateLeague;
        }

        private void View_OnUpdateLeague(object sender, IdEventArgs e)
        {
            League league = this.leagueService.GetLeagueById(e.Id);

            if (league == null)
            {
                this.View.ModelState.
                     AddModelError("", String.Format("Item with id {0} was not found", e.Id));
                return;
            }

            this.View.TryUpdateModel(league);
            if (this.View.ModelState.IsValid)
            {
                this.leagueService.UpdateLeague(league);
            }
        }

        private void View_OnDeleteLeague(object sender, IdEventArgs e)
        {
            League league = this.leagueService.GetLeagueById(e.Id);

            if (league == null)
            {
                this.View.ModelState.
                     AddModelError("", String.Format("Item with id {0} was not found", e.Id));
                return;
            }

            this.View.TryUpdateModel(league);
            if (this.View.ModelState.IsValid)
            {
                this.leagueService.DeleteLeague(league);
            }
        }

        private void View_OnAddLeague(object sender, EventArgs eventArgs)
        {
            League league = new League();
            this.View.TryUpdateModel(league);
            if (this.View.ModelState.IsValid)
            {
                this.leagueService.AddNewLeague(league);
            }
        }

        private void View_OnGetAllCountries(object sender, EventArgs eventArgs)
        {
            this.View.Model.Countries = this.countryService.GetAllCountries();
        }

        private void View_OnGetAllLeagues(object sender, EventArgs eventArgs)
        {
            this.View.Model.Leagues = this.leagueService.GetAlLeagues();
        }
    }
}
