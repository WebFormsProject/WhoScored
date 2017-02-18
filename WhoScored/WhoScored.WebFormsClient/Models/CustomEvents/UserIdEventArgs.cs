using System;

namespace WhoScored.WebFormsClient.Models.CustomEvents
{
    public class UserIdEventArgs : EventArgs
    {
        public UserIdEventArgs(string id)
        {
            this.Id = id;

        }

        public string Id { get; set; }
    }
}