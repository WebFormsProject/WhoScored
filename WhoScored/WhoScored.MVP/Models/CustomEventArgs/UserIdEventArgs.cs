using System;

namespace WhoScored.MVP.Models.CustomEventArgs
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