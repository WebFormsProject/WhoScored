using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhoScored.Models.Models;
using WhoScored.WebFormsClient.Models;
using WhoScored.WebFormsClient.Models.CustomEvents;
using WhoScored.WebFormsClient.Presenters;
using WhoScored.WebFormsClient.Views;

namespace WhoScored.WebFormsClient
{
    [PresenterBinding(typeof(LeagueTablePresenter))]
    public partial class LeaguesTable : MvpPage<LeagueTablesViewModel>, ILeagueTableView
    {
        public event EventHandler<LeagueTableEventArgs> OnGetLeagueTableData;

        public IEnumerable<TeamStatistic> GridViewLeagueTable_GetData()
        {
            int id = int.Parse(this.Request.QueryString["id"]);
            this.OnGetLeagueTableData?.Invoke(this, new LeagueTableEventArgs(id));

            return this.Model.LeagueTable.TeamStatistics;
        }
    }
}