using System;
using System.Collections.Generic;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhoScored.WebFormsClient.Models;
using WhoScored.WebFormsClient.Presenters;
using WhoScored.WebFormsClient.Views;

namespace WhoScored.WebFormsClient
{
    [PresenterBinding(typeof(StatisticsPresenter))]
    public partial class Statistics : MvpPage<StatisticsViewModel>, IStatisticsView
    {
        public event EventHandler GetTeams;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GetTeams?.Invoke(sender, e);

            this.StatisticsGridView.DataSource = this.Model.Teams.ToList();
            this.StatisticsGridView.DataBind();
        }
    }
}