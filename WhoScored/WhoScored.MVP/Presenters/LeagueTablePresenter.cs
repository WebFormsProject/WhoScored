using Bytes2you.Validation;
using WebFormsMvp;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.MVP.Models.CustomEvents;
using WhoScored.MVP.Views;

namespace WhoScored.MVP.Presenters
{
    public class LeagueTablePresenter : Presenter<ILeagueTableView>
    {
        private readonly IWhoScoredRepository<LeagueTable> leagueTableRepository;

        public LeagueTablePresenter(ILeagueTableView view, IWhoScoredRepository<LeagueTable> leagueTableRepository) 
            : base(view)
        {
            Guard.WhenArgument(leagueTableRepository, "leagueTableRepository").IsNull().Throw();
            this.leagueTableRepository = leagueTableRepository;

            this.View.OnGetLeagueTableData += this.View_OnGetLeaguesTable;
        }

        private void View_OnGetLeaguesTable(object sender, IdEventArgs e)
        {
            this.View.Model.LeagueTable = this.leagueTableRepository.GetById(e.Id);
        }
    }
}