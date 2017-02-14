using System;
using WebFormsMvp;
using WhoScored.WebFormsClient.Models;
using WhoScored.WebFormsClient.Models.CustomEvents;

namespace WhoScored.WebFormsClient.Views
{
    public interface ILeagueTableView : IView<LeagueTablesViewModel>
    {
        event EventHandler<LeagueTableEventArgs> GetLeagueTables;
    }
}