using System;
using Bytes2you.Validation;
using WebFormsMvp;
using WhoScored.MVP.Views;
using WhoScored.Services.Contracts;

namespace WhoScored.MVP.Presenters
{
    public class AddFootballPlayerPresenter : Presenter<IAddFootballPlayerView>
    {
        private readonly IFootballPlayerService footballPlayerService; 

        public AddFootballPlayerPresenter(IAddFootballPlayerView view, IFootballPlayerService footballPlayerService) 
            : base(view)
        {
            Guard.WhenArgument(footballPlayerService, "footballPlayerService").IsNull().Throw();
            this.footballPlayerService = footballPlayerService;

            this.View.OnGetAllPlayers += View_OnGetAllPlayers;
        }

        private void View_OnGetAllPlayers(object sender, EventArgs eventArgs)
        {
            this.View.Model.FootballPlayers = this.footballPlayerService.GetAllFootballPlayers();
        }
    }
}
