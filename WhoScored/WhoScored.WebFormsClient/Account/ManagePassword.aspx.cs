using System;
using Microsoft.AspNet.Identity;
using WebFormsMvp;
using WhoScored.MVP.Presenters.Auth;
using WebFormsMvp.Web;
using WhoScored.MVP.Models.Auth;
using WhoScored.MVP.Views.Auth;
using WhoScored.MVP.Models.CustomEventArgs;

namespace WhoScored.WebFormsClient.Account
{
    [PresenterBinding(typeof(ManagePasswordPresenter))]
    public partial class ManagePassword : MvpPage<ManagePasswordViewModel>, IManagePasswordView
    {
        public event EventHandler<ManagePasswordEventArgs> ManagingPassword;

        protected string SuccessMessage { get; set; }

        protected void Page_Load()
        {
            this.ManagingPassword?.Invoke(this, new ManagePasswordEventArgs(
                this.Context,
                this.User.Identity,
                this.CurrentPassword.Text,
                this.NewPassword.Text,
                false,
                false));

            if (!this.Page.IsPostBack)
            {
                if (this.Model.HasPassword)
                {
                    this.changePasswordHolder.Visible = true;
                }
                else
                {
                    this.changePasswordHolder.Visible = false;
                }

                string message = Request.QueryString["m"];
                if (message != null)
                {
                    Form.Action = ResolveUrl("~/Account/Manage");
                }
            }
        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                if (this.Model.IdentityResult.Succeeded)
                {
                    Response.Redirect("~/Account/Manage?m=ChangePwdSuccess");
                }
                else
                {
                    AddErrors(this.Model.IdentityResult);
                }
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}