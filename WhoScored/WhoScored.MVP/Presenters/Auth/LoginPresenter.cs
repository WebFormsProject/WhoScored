using System.Web;
using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using WhoScored.MVP.Views.Auth;
using WhoScored.MVP.Identity;
using WhoScored.MVP.Models.CustomEventArgs;

namespace WhoScored.MVP.Presenters.Auth
{
    public class LoginPresenter : Presenter<ILoginView>
    {
        public LoginPresenter(ILoginView view)
            : base(view)
        {
            this.View.Logging += this.View_OnLogging;
        }

        private void View_OnLogging(object sender, LoginEventArgs e)
        {
            ApplicationUserManager manager = e.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationSignInManager signinManager = e.HttpContext.GetOwinContext().GetUserManager<ApplicationSignInManager>();

            // To enable password failures to trigger lockout, change to shouldLockout: true
            this.View.Model.SignInStatus = signinManager.PasswordSignIn(e.Username, e.Password, e.RememberMe, e.ShouldLockOut);
        }
    }
}
