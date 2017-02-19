using System;
using WhoScored.Models.Models;

namespace WhoScored.MVP.Models.CustomEventArgs
{
    public class GameNameEventArgs : EventArgs
    {
        public GameNameEventArgs(League league)
        {
            this.League = league;
        }

        public League League { get; set; }
    }
}