using System;
using Bytes2you.Validation;
using WebFormsMvp;
using WhoScored.MVP.Views;
using WhoScored.Services.Contracts;

namespace WhoScored.MVP.Presenters
{
    public class LeaguePresenter : Presenter<ILeaguesView>
    {
        private readonly ILeagueService leagueService; 

        public LeaguePresenter(ILeaguesView view, ILeagueService leagueService)
            : base(view)
        {
           Guard.WhenArgument(leagueService, "leagueService").IsNull().Throw();
            this.leagueService = leagueService;

            this.View.OnGetLeagues += View_GetLeagues;
        }

        private void View_GetLeagues(object sender, EventArgs e)
        {
           this.View.Model.Leagues = this.leagueService.GetAlLeagues();
        }
    }
}