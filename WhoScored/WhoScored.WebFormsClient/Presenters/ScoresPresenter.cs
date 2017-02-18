using System;
using Bytes2you.Validation;
using WebFormsMvp;
using WhoScored.Services.Contracts;
using WhoScored.WebFormsClient.Models.CustomEvents;
using WhoScored.WebFormsClient.Views;

namespace WhoScored.WebFormsClient.Presenters
{
    public class ScoresPresenter : Presenter<IScoresView>
    {
        private readonly IGameService gameService;

        public ScoresPresenter(IScoresView view, IGameService gameService) 
            : base(view)
        {
            Guard.WhenArgument(gameService, "gameService").IsNull().Throw();
            this.gameService = gameService;

            this.View.OnGetLeagues += View_OnGetLeagues;
            this.View.OnGetGameByLeague += View_OnGetGameByLeague;
        }

        private void View_OnGetGameByLeague(object sender, GameNameEventArgs gameNameEventArgs)
        {
            this.View.Model.GamesByLeague = this.gameService.GetGamesByLeague(gameNameEventArgs.League);
        }

        private void View_OnGetLeagues(object sender, EventArgs eventArgs)
        {
            this.View.Model.Leagues = this.gameService.GetGroupedLeagues();
        }
    }
}