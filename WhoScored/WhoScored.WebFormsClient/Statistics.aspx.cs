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
        public event EventHandler<StatisticsEventArgs> MyInit;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.MyInit?.Invoke(sender, new StatisticsEventArgs());

            this.StatisticsFormView.DataSource = this.Model.Teams;
            this.StatisticsFormView.DataBind();
        }
    }
}