using System;
using WebFormsMvp;
using WhoScored.WebFormsClient.Models;

namespace WhoScored.WebFormsClient.Views
{
    public interface IStatisticsView :IView<StatisticsViewModel>
    {
        event EventHandler<StatisticsEventArgs> MyInit;
    }
}
