using Bytes2you.Validation;
using System.Security.Principal;
using System.Web;

namespace WhoScored.MVP.Models.CustomEventArgs
{
    public class ManagePasswordEventArgs : ManageAccountEventArgs
    {
        public ManagePasswordEventArgs(HttpContext httpContext, IIdentity user, string currentPassword, string newPassword, bool isPersistent, bool rememberBrowser)
            : base(httpContext, user)
        {
            Guard.WhenArgument(currentPassword, "currentPassword").IsNull().Throw();
            Guard.WhenArgument(newPassword, "newPassword").IsNull().Throw();

            this.CurrentPassword = currentPassword;
            this.NewPassword = newPassword;
            this.IsPersistent = isPersistent;
            this.RememberBrowser = rememberBrowser;
        }

        public string CurrentPassword { get; private set; }

        public string NewPassword { get; private set; }

        public bool IsPersistent { get; private set; }

        public bool RememberBrowser { get; private set; }
    }
}
