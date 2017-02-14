using WebFormsMvp;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.WebFormsClient.Models.CustomEvents;
using WhoScored.WebFormsClient.Views;

namespace WhoScored.WebFormsClient.Presenters
{
    public class LeagueTablePresenter : Presenter<ILeagueTableView>
    {
        private readonly IWhoScoredRepository<LeagueTable> leagueTableRepository;

        public LeagueTablePresenter(ILeagueTableView view, IWhoScoredRepository<LeagueTable> leagueTableRepository) 
            : base(view)
        {
            this.leagueTableRepository = leagueTableRepository;

            this.View.GetLeagueTables += this.View_GetLeaguesTable;
        }

        private void View_GetLeaguesTable(object sender, LeagueTableEventArgs e)
        {
            this.View.Model.LeagueTable = this.leagueTableRepository.GetById(e.Id);
         //   this.View.Model.TeamStatistics = this.leagueTableRepository.GetById(e.Id).TeamStatistics;
        }
    }
}