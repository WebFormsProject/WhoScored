using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using WebFormsMvp;
using WhoScored.MVP.Identity;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Views.Auth;

namespace WhoScored.MVP.Presenters.Auth
{
    public class ManagePasswordPresenter : Presenter<IManagePasswordView>
    {
        public ManagePasswordPresenter(IManagePasswordView view)
            : base(view)
        {
            this.View.ManagingPassword += this.View_ManagingPassword;
        }

        private void View_ManagingPassword(object sender, ManagePasswordEventArgs e)
        {
            ApplicationUserManager manager = e.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationSignInManager signInManager = e.HttpContext.GetOwinContext().Get<ApplicationSignInManager>();

            this.View.Model.HasPassword = manager.HasPassword(e.User.GetUserId());
            this.View.Model.IdentityResult = manager.ChangePassword(e.User.GetUserId(), e.CurrentPassword, e.NewPassword);
        }
    }
}
