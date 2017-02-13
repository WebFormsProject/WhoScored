using System;
using Bytes2you.Validation;
using WebFormsMvp;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.WebFormsClient.Views;

namespace WhoScored.WebFormsClient.Presenters
{
    public class LeaguePresenter : Presenter<ILeaguesView>
    {
        private readonly IWhoScoredRepository<League> leagueRepository; 

        public LeaguePresenter(ILeaguesView view, IWhoScoredRepository<League> leagueRepository)
            : base(view)
        {
           Guard.WhenArgument(leagueRepository, "leagueRepository").IsNull();
            this.leagueRepository = leagueRepository;

            this.View.GetLeagues += View_GetLeagues;
        }

        private void View_GetLeagues(object sender, EventArgs e)
        {
           this.View.Model.Leagues = this.leagueRepository.GetAll();
        }
    }
}