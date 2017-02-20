using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using WebFormsMvp;
using WhoScored.Models.Models;
using WhoScored.MVP.Identity;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Views.Auth;

namespace WhoScored.MVP.Presenters.Auth
{
    public class RegisterPresenter : Presenter<IRegisterView>
    {
        public RegisterPresenter(IRegisterView view)
            : base(view)
        {
            this.View.Registering += this.View_OnRegistering;
        }

        private void View_OnRegistering(object sender, RegisterEventArgs e)
        {
            ApplicationUserManager manager = e.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationSignInManager signInManager = e.HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            User user = new User()
            {
                UserName = e.Username,
                Email = e.Email,
                FirstName = e.FirstName,
                LastName = e.LastName
            };

            IdentityResult result = manager.Create(user, e.Password);
            if (result.Succeeded)
            {
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
            }

            this.View.Model.IdentityResult = result;
        }
    }
}
