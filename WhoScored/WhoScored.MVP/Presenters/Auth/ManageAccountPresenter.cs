using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web;
using WebFormsMvp;
using WhoScored.MVP.Identity;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Views.Auth;

namespace WhoScored.MVP.Presenters.Auth
{
    public class ManageAccountPresenter : Presenter<IManageAccountView>
    {
        public ManageAccountPresenter(IManageAccountView view)
            : base(view)
        {
            this.View.ManagingAccount += this.View_ManagingAccount;
        }

        private void View_ManagingAccount(object sender, ManageAccountEventArgs e)
        {
            ApplicationUserManager manager = e.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            IAuthenticationManager authenticationManager = e.HttpContext.GetOwinContext().Authentication;

            this.View.Model.HasPassword = manager.HasPassword(e.User.GetUserId());
        }
    }
}
