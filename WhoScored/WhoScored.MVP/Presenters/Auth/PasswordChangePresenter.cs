using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using WebFormsMvp;
using WhoScored.MVP.Identity;
using WhoScored.MVP.Models.CustomEvents;
using WhoScored.MVP.Views.Auth;

namespace WhoScored.MVP.Presenters.Auth
{
    public class PasswordChangePresenter : Presenter<IPasswordChangeView>
    {
        public PasswordChangePresenter(IPasswordChangeView view)
            : base(view)
        {
            this.View.ChangePassword += this.View_OnPasswordChange;
        }

        private void View_OnPasswordChange(object sender, PasswordChangeEventArgs e)
        {
            ApplicationUserManager manager = e.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            IdentityResult result = manager.ResetPassword(e.User.GetUserId(), e.CurrentPassword, e.NewPassword);

            this.View.Model.IdentityResult = result;
        }
    }
}
