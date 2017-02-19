using System;
using WhoScored.Models.Models;

namespace WhoScored.MVP.Models.CustomEvents
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