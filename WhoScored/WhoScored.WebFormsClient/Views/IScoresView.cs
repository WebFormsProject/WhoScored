using System;
using WebFormsMvp;
using WhoScored.WebFormsClient.Models;
using WhoScored.WebFormsClient.Models.CustomEvents;

namespace WhoScored.WebFormsClient.Views
{
    public interface IScoresView : IView<ScoresModelView>
    {
        event EventHandler OnGetLeagues;

        event EventHandler<GameNameEventArgs> OnGetGameByLeague;
    }
}
