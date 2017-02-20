using Bytes2you.Validation;
using System;

namespace WhoScored.MVP.Models.CustomEventArgs
{
    public class UserIdEventArgs : EventArgs
    {
        public UserIdEventArgs(string id)
        {
            Guard.WhenArgument(id, "id").IsNull().Throw();

            this.Id = id;
        }

        public string Id { get; private set; }
    }
}