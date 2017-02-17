using System;
using WebFormsMvp;
using WhoScored.WebFormsClient.Models;

namespace WhoScored.WebFormsClient.Views
{
    public interface ILeaguesView : IView<LeaguesViewModel>
    {
        event EventHandler OnGetLeagues;
    }
}