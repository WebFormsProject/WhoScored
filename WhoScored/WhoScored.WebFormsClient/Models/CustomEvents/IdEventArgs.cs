using System;

namespace WhoScored.WebFormsClient.Models.CustomEvents
{
    public class IdEventArgs : EventArgs
    {
        public IdEventArgs(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}