using System;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhoScored.MVP.Models;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;

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