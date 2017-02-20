using Microsoft.AspNet.Identity;
using System;
using System.IO;
using System.Web;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhoScored.MVP.Models.Auth;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Presenters.Auth;
using WhoScored.MVP.Views.Auth;

namespace WhoScored.WebFormsClient.Account
{
    [PresenterBinding(typeof(UserAvatarPresenter))]
    public partial class ManageAvatar : MvpPage<UserAvatarViewModelcs>, IUserAvatarView
    {
        public event EventHandler<UserIdEventArgs> GetAvatar;
        public event EventHandler<UserAvatarEventArgs> UploadAvatar;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.GetAvatar?.Invoke(this, new UserIdEventArgs(this.User.Identity.GetUserId()));
                this.AvatarImage.ImageUrl = this.Model.UserAvatarUrl;
            }
        }

        protected void UploadAvatarButton_Click(object sender, EventArgs e)
        {
            if (this.AvatarFileUpload.HasFile)
            {
                string username = this.Context.User.Identity.Name;
                HttpPostedFile postedFile = this.AvatarFileUpload.PostedFile;
                HttpPostedFileBase fileBase = new HttpPostedFileWrapper(postedFile);
                string extension = Path.GetExtension(postedFile.FileName);
                string filename = username + extension;
                string storageLocation = Server.MapPath($"~/photos/Avatars/{filename}");
                string filePath = $"/photos/Avatars/{filename}";

                this.UploadAvatar?.Invoke(this, new UserAvatarEventArgs(
                    fileBase,
                    filePath,
                    storageLocation,
                    this.User.Identity.GetUserId()));
            }
        }
    }
}