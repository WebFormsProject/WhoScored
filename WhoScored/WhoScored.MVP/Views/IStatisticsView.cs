using System;
using WebFormsMvp;
using WhoScored.MVP.Models;

namespace WhoScored.MVP.Views
{
    public interface IStatisticsView : IView<StatisticsViewModel>
    {
        event EventHandler GetTeams;
    }
}
