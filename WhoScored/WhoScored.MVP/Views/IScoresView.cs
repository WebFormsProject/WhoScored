using System;
using WebFormsMvp;
using WhoScored.MVP.Models;
using WhoScored.MVP.Models.CustomEventArgs;

namespace WhoScored.MVP.Views
{
    public interface IScoresView : IView<ScoresModelView>
    {
        event EventHandler OnGetLeagues;

        event EventHandler<GameNameEventArgs> OnGetGameByLeague;

        event EventHandler<IdEventArgs> OnGetGameById;
    }
}
