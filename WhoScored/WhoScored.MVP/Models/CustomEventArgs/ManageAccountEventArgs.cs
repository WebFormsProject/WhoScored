using Bytes2you.Validation;
using System;
using System.Security.Principal;
using System.Web;

namespace WhoScored.MVP.Models.CustomEventArgs
{
    public class ManageAccountEventArgs : EventArgs
    {
        public ManageAccountEventArgs(HttpContext httpContext, IIdentity user)
        {
            Guard.WhenArgument(httpContext, "httpContext").IsNull().Throw();
            Guard.WhenArgument(user, "user").IsNull().Throw();

            this.HttpContext = httpContext;
            this.User = user;
        }

        public HttpContext HttpContext { get; set; }

        public IIdentity User { get; private set; }
    }
}
