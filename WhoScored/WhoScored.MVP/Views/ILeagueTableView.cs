using System;
using WebFormsMvp;
using WhoScored.MVP.Models;
using WhoScored.MVP.Models.CustomEvents;

namespace WhoScored.MVP.Views
{
    public interface ILeagueTableView : IView<LeagueTablesViewModel>
    {
        event EventHandler<IdEventArgs> OnGetLeagueTableData;
    }
}