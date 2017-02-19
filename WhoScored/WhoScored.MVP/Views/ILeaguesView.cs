using System;
using WebFormsMvp;
using WhoScored.MVP.Models;

namespace WhoScored.MVP.Views
{
    public interface ILeaguesView : IView<LeaguesViewModel>
    {
        event EventHandler OnGetLeagues;
    }
}