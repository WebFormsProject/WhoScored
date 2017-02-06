using Microsoft.AspNet.Identity;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WhoScored.WebFormsClient
{
    public partial class Public : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}