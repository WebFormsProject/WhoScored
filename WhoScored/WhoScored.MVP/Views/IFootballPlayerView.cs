using System;
using WebFormsMvp;
using WhoScored.MVP.Models;
using WhoScored.MVP.Models.CustomEvents;

namespace WhoScored.MVP.Views
{
    public interface IFootballPlayerView : IView<FootballPlayerViewModel>
    {
        event EventHandler<IdEventArgs> OnGetFootballPlayerById; 
    }
}
