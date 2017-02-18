using System;
using Bytes2you.Validation;
using WebFormsMvp;
using WhoScored.Services.Contracts;
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

            this.View.OnGetLatestScores += View_OnOnGetLatestScores;
        }

        private void View_OnOnGetLatestScores(object sender, EventArgs eventArgs)
        {
            this.View.Model.Games = this.gameService.GetGamesGroupedByLeague();
        }
    }
}