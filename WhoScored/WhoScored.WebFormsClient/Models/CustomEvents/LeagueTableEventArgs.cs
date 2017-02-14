using System;

namespace WhoScored.WebFormsClient.Models.CustomEvents
{
    public class LeagueTableEventArgs : EventArgs
    {
        public LeagueTableEventArgs(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}