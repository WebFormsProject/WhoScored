using System;

namespace WhoScored.WebFormsClient.Models.CustomEvents
{
    public class TeamEventArgs : EventArgs
    {
        public TeamEventArgs(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}