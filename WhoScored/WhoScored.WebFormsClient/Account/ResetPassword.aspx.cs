using System;
using WebFormsMvp;
using WhoScored.MVP.Presenters.Auth;
using WebFormsMvp.Web;
using WhoScored.MVP.Models.Auth;
using WhoScored.MVP.Views.Auth;
using WhoScored.MVP.Models.CustomEventArgs;
using System.Linq;

namespace WhoScored.WebFormsClient.Account
{
    [PresenterBinding(typeof(PasswordChangePresenter))]
    public partial class ResetPassword : MvpPage<PasswordChangeViewModel>, IPasswordChangeView
    {
        public event EventHandler<PasswordChangeEventArgs> ChangePassword;

        protected void Reset_Click(object sender, EventArgs e)
        {
            this.ChangePassword?.Invoke(this, new PasswordChangeEventArgs(
                this.Context,
                this.User.Identity,
                this.Password.Text,
                this.ConfirmPassword.Text
                ));

            if (this.Model.IdentityResult.Succeeded)
            {
                Response.Redirect("~/Account/Login");
            }
            else
            {
                ErrorMessage.Text = this.Model.IdentityResult.Errors.FirstOrDefault();
            }
        }
    }
}