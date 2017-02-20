using System;
using WebFormsMvp;
using WhoScored.MVP.Presenters.Auth;
using WhoScored.MVP.Models.Auth;
using WebFormsMvp.Web;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Views.Auth;

namespace WhoScored.WebFormsClient.Account
{
    [PresenterBinding(typeof(ManageAccountPresenter))]
    public partial class Manage : MvpPage<ManageAccountViewModel>, IManageAccountView
    {
        public event EventHandler<ManageAccountEventArgs> ManagingAccount;

        protected string SuccessMessage { get; set; }

        protected void Page_Load()
        {
            this.ManagingAccount?.Invoke(this, new ManageAccountEventArgs(this.Context, this.User.Identity));

            if (!this.Page.IsPostBack)
            {
                if (this.Model.HasPassword)
                {
                    this.ChangePassword.Visible = true;
                }
                else
                {
                    this.ChangePassword.Visible = false;
                }

                string message = Request.QueryString["m"];
                if (message != null)
                {
                    Form.Action = ResolveUrl("~/Account/Manage");

                    if (message == "ChangePasswordSuccess")
                    {
                        this.successMessage.Visible = true;
                        this.SuccessMessage = "Your password has been changed.";
                    }
                    else if (message == "ChangeAvatarSuccess")
                    {
                        this.successMessage.Visible = true;
                        this.SuccessMessage = "Your profile picture has been changed.";
                    }
                    else
                    {
                        this.successMessage.Visible = false; ;
                    }
                }
            }
        }
    }
}