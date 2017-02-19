using Bytes2you.Validation;
using WebFormsMvp;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Views;
using WhoScored.Services.Contracts;

namespace WhoScored.MVP.Presenters
{
    public class FootballPlayerPresenter : Presenter<IFootballPlayerView>
    {
        private readonly IFootballPlayerService footballPlayerService;

        public FootballPlayerPresenter(IFootballPlayerView view, IFootballPlayerService footballPlayerService)
            : base(view)
        {
            Guard.WhenArgument(footballPlayerService, "footballPlayerService").IsNull().Throw();
            this.footballPlayerService = footballPlayerService;

            this.View.OnGetFootballPlayerById += View_OnGetFootballPlayerById;
        }

        private void View_OnGetFootballPlayerById(object sender, IdEventArgs idEventArgs)
        {
            this.View.Model.FootballPlayer = this.footballPlayerService.GetFootballPlayerById(idEventArgs.Id);
        }
    }
}
