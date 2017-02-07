using System.Collections.Generic;
using WebFormsMvp;
using WhoScored.Models.Models;
using WhoScored.WebFormsClient.Models;
using WhoScored.WebFormsClient.Views;

namespace WhoScored.WebFormsClient.Presenters
{
    public class StatisticsPresenter : Presenter<IStatisticsView>
    {
        //private readonly IDataProvider dataProvider;

        public StatisticsPresenter(IStatisticsView view)
            : base(view)
        {
            //this.dataProvider = dataProvider;

            this.View.MyInit += this.View_MyInit;
        }

        private void View_MyInit(object sender, StatisticsEventArgs e)
        {
            //this.View.Model.Names = this.dataProvider.GetTeamNamesById(e.Id);
            this.View.Model.Teams = new List<Team>()
            {
                new Team
                {
                    Id = 1,
                    Name = "test",
                    FootballPlayers=new HashSet<FootballPlayer>
                     {
                         new FootballPlayer
                         {
                              LastName = "test name"
                         },
                         new FootballPlayer
                         {
                             LastName = "name test"
                         }
                     },
                     Titles = new HashSet<Title>
                     {
                         new Title
                         {
                              TitleName = "test title"
                         }
                     }
                }
            };
        }
    }
}