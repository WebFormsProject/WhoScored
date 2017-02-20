using Bytes2you.Validation;
using WebFormsMvp;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Views;
using WhoScored.Services.Contracts;

namespace WhoScored.MVP.Presenters
{
    public class LeagueTablePresenter : Presenter<ILeagueTableView>
    {
        private readonly ILeagueTableService leagueTableService;

        public LeagueTablePresenter(ILeagueTableView view, ILeagueTableService leagueTableService) 
            : base(view)
        {
            Guard.WhenArgument(leagueTableService, "leagueTableService").IsNull().Throw();
            this.leagueTableService = leagueTableService;

            this.View.OnGetLeagueTableData += this.View_OnGetLeaguesTable;
        }

        private void View_OnGetLeaguesTable(object sender, IdEventArgs e)
        {
            this.View.Model.LeagueTable = this.leagueTableService.GetLeagueTableById(e.Id);
        }
    }
}