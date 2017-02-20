using System;
using WebFormsMvp;
using WhoScored.MVP.Models;

namespace WhoScored.MVP.Views
{
    public interface IAddFootballPlayerView : IView<AddFootballPlayerViewModel>
    {
        event EventHandler OnGetAllPlayers;


    }
}
