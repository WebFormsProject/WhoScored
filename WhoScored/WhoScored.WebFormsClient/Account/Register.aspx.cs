using System;
using System.Web;
using System.IO;
using System.Linq;
using WhoScored.MVP.Identity;
using WebFormsMvp.Web;
using WhoScored.MVP.Models.Auth;
using WhoScored.MVP.Views.Auth;
using WebFormsMvp;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Presenters.Auth;

namespace WhoScored.WebFormsClient.Account
{
    [PresenterBinding(typeof(RegisterPresenter))]
    public partial class Register : MvpPage<RegisterViewModel>, IRegisterView
    {
        public event EventHandler<RegisterEventArgs> Registering;

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            if (this.AvatarFileUpload.HasFile)
            {
                string username = this.Username.Text;
                HttpPostedFile postedFile = this.AvatarFileUpload.PostedFile;
                HttpPostedFileBase fileBase = new HttpPostedFileWrapper(postedFile);

                string extension = Path.GetExtension(postedFile.FileName);
                string filename = username + extension;
                string avatarFilePath = "/photos/Avatars/" + filename;
                string storageLocation = Server.MapPath($"~{avatarFilePath}");

                this.Registering?.Invoke(this, new RegisterEventArgs(
                this.Context,
                Server.HtmlEncode(this.Username.Text),
                Server.HtmlEncode(this.Password.Text),
                Server.HtmlEncode(this.Email.Text),
                Server.HtmlEncode(this.FirstName.Text),
                Server.HtmlEncode(this.LastName.Text),
                fileBase,
                avatarFilePath,
                storageLocation));
            }
            else
            {
                this.Registering?.Invoke(this, new RegisterEventArgs(
                this.Context,
                this.Username.Text,
                this.Password.Text,
                this.Email.Text,
                this.FirstName.Text,
                this.LastName.Text));
            }

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