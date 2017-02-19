using Bytes2you.Validation;
using WebFormsMvp;
using WhoScored.Data.Contracts;
using WhoScored.MVP.Models.CustomEvents;
using WhoScored.MVP.Views;

namespace WhoScored.MVP.Presenters
{
    public class TeamPresenter : Presenter<ITeamView>
    {
        private readonly IWhoScoredRepository<WhoScored.Models.Models.Team> teamRepository;

        public TeamPresenter(ITeamView view, IWhoScoredRepository<WhoScored.Models.Models.Team> teamRepository) 
            : base(view)
        {
            Guard.WhenArgument(teamRepository, "teamRepository").IsNull().Throw();
            this.teamRepository = teamRepository;

            this.View.OnGetTeam += View_OnOnGetTeam;
        }

        private void View_OnOnGetTeam(object sender, IdEventArgs e)
        {
            this.View.Model.Team = this.teamRepository.GetById(e.Id);
        }
    }
}