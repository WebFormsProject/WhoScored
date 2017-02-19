using System;
using System.Linq;
using WhoScored.MVP.Identity;
using WebFormsMvp.Web;
using WhoScored.MVP.Models.Auth;
using WhoScored.MVP.Views.Auth;
using WebFormsMvp;
using WhoScored.MVP.Models.CustomEvents;
using WhoScored.MVP.Presenters.Auth;

namespace WhoScored.WebFormsClient.Account
{
    [PresenterBinding(typeof(RegisterPresenter))]
    public partial class Register : MvpPage<RegisterViewModel>, IRegisterView
    {
        public event EventHandler<RegisterEventArgs> Registering;

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            this.Registering?.Invoke(this, new RegisterEventArgs(
                this.Context,
                this.Username.Text,
                this.Password.Text,
                this.Email.Text,
                this.FirstName.Text,
                this.LastName.Text));

            if (this.Model.IdentityResult.Succeeded)
            {
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = this.Model.IdentityResult.Errors.FirstOrDefault();
            }
        }
    }
}