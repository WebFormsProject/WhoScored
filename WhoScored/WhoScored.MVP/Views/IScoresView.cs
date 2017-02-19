﻿using System;
using WebFormsMvp;
using WhoScored.MVP.Models;
using WhoScored.MVP.Models.CustomEvents;

namespace WhoScored.MVP.Views
{
    public interface IScoresView : IView<ScoresViewModel>
    {
        event EventHandler OnGetLeagues;

        event EventHandler<GameNameEventArgs> OnGetGameByLeague;

        event EventHandler<IdEventArgs> OnGetGameById;
    }
}
