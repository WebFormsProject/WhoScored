using System;
using System.Collections.Generic;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhoScored.Models.Models;
using WhoScored.MVP.Models;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;

namespace WhoScored.WebFormsClient
{
    [PresenterBinding(typeof(LeagueTablePresenter))]
    public partial class LeaguesTable : MvpPage<LeagueTablesViewModel>, ILeagueTableView
    {
        public event EventHandler<IdEventArgs> OnGetLeagueTableData;

        public IEnumerable<TeamStatistic> GridViewLeagueTable_GetData()
        {
            int id = int.Parse(this.Request.QueryString["id"]);
            this.OnGetLeagueTableData?.Invoke(this, new IdEventArgs(id));

            return this.Model.LeagueTable.TeamStatistics;
        }
    }
}