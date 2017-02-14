using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhoScored.WebFormsClient.Models;
using WhoScored.WebFormsClient.Models.CustomEvents;
using WhoScored.WebFormsClient.Presenters;
using WhoScored.WebFormsClient.Views;

namespace WhoScored.WebFormsClient
{
    [PresenterBinding(typeof(LeagueTablePresenter))]
    public partial class LeaguesTable : MvpPage<LeagueTablesViewModel>, ILeagueTableView
    {
        public event EventHandler<LeagueTableEventArgs> GetLeagueTables;

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(this.Request.QueryString["id"]);
            this.GetLeagueTables?.Invoke(sender, new LeagueTableEventArgs(id));

       // this.Response.Write(this.Model.LeagueTable);

          this.LeaguesStatisticsGridView.DataSource = this.Model.LeagueTable.TeamStatistics.ToList();
            this.LeaguesStatisticsGridView.DataBind();
        }

    }
}