using System;
using WebFormsMvp;
using WhoScored.WebFormsClient.Models;
using WhoScored.WebFormsClient.Models.CustomEvents;

namespace WhoScored.WebFormsClient.Views
{
    public interface ITeamView : IView<TeamViewModel>
    {
        event EventHandler<TeamEventArgs> OnGetTeam;
    }
}