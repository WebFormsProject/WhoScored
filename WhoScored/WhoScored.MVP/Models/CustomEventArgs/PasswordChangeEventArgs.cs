using Bytes2you.Validation;
using System;
using System.Security.Principal;
using System.Web;

namespace WhoScored.MVP.Models.CustomEventArgs
{
    public class PasswordChangeEventArgs : EventArgs
    {
        public PasswordChangeEventArgs(HttpContext httpContext, IIdentity user, string currentPassword, string newPassword)
        {
            Guard.WhenArgument(httpContext, "httpContext").IsNull().Throw();
            Guard.WhenArgument(user, "user").IsNull().Throw();
            Guard.WhenArgument(currentPassword, "currentPassword").IsNull().Throw();
            Guard.WhenArgument(newPassword, "newPassword").IsNull().Throw();

            this.HttpContext = httpContext;
            this.User = user;
            this.CurrentPassword = currentPassword;
            this.NewPassword = newPassword;
        }

        public HttpContext HttpContext { get; set; }

        public IIdentity User { get; set; }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
