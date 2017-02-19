using System;

namespace WhoScored.MVP.Models.CustomEvents
{
    public class UserIdEventArgs : EventArgs
    {
        public UserIdEventArgs(string id)
        {
            this.Id = id;
        }

        public string Id { get; private set; }
    }
}