using Bytes2you.Validation;
using System.Collections.Generic;
using WebFormsMvp;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.WebFormsClient.Models;
using WhoScored.WebFormsClient.Views;

namespace WhoScored.WebFormsClient.Presenters
{
    public class StatisticsPresenter : Presenter<IStatisticsView>
    {
        private readonly IWhoScoredRepository<Team> dataProvider;

        public StatisticsPresenter(IStatisticsView view)
            : base(view)
        {
            Guard.WhenArgument(this.dataProvider, "dataProvider").IsNull();
            //this.dataProvider = dataProvider;

            this.View.MyInit += this.View_MyInit;
        }

        private void View_MyInit(object sender, StatisticsEventArgs e)
        {
            this.View.Model.Teams = new List<Team> //this.dataProvider.GetAll()
            {
                new Team
                {
                    Name = "test"
                }
            };
        }
    }
}