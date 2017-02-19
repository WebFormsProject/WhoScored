using Bytes2you.Validation;
using System;
using System.Web;

namespace WhoScored.MVP.Models.CustomEventArgs
{
    public class LoginEventArgs : EventArgs
    {
        public LoginEventArgs(HttpContext httpContext, string username, string password, bool rememberMe, bool shouldLockout)
        {
            Guard.WhenArgument(httpContext, "httpContext").IsNull().Throw();
            Guard.WhenArgument(username, "username").IsNull().Throw();
            Guard.WhenArgument(password, "password").IsNull().Throw();

            this.HttpContext = httpContext;
            this.Username = username;
            this.Password = password;
            this.RememberMe = rememberMe;
            this.ShouldLockOut = shouldLockout;
        }

        public HttpContext HttpContext { get; set; }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public bool RememberMe { get; private set; }

        public bool ShouldLockOut { get; private set; }
    }
}
