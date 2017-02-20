using Bytes2you.Validation;
using WebFormsMvp;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Views;
using WhoScored.Services.Contracts;

namespace WhoScored.MVP.Presenters
{
    public class TeamPresenter : Presenter<ITeamView>
    {
        private readonly ITeamService teamService;

        public TeamPresenter(ITeamView view,  ITeamService teamService) 
            : base(view)
        {
            Guard.WhenArgument(teamService, "teamService").IsNull().Throw();
            this.teamService = teamService;

            this.View.OnGetTeam += View_OnOnGetTeam;
        }

        private void View_OnOnGetTeam(object sender, IdEventArgs e)
        {
            this.View.Model.Team = this.teamService.GetTeamById(e.Id);
        }
    }
}