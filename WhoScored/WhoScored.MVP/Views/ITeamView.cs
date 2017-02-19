using System;
using WebFormsMvp;
using WhoScored.MVP.Models;
using WhoScored.MVP.Models.CustomEvents;

namespace WhoScored.MVP.Views
{
    public interface ITeamView : IView<TeamViewModel>
    {
        event EventHandler<IdEventArgs> OnGetTeam;
    }
}