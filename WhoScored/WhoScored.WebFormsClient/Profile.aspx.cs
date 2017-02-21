using Microsoft.AspNet.Identity;
using System;
using System.IO;
using System.Web;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhoScored.MVP.Models;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;

namespace WhoScored.WebFormsClient
{
    [PresenterBinding(typeof(UserPresenter))]
    public partial class Profile : MvpPage<UserViewModel>, IUserView
    {
        private const string DefaultAvatarPath = "/photos/Avatars/default.png";

        public event EventHandler<UserIdEventArgs> GetUser;
        public event EventHandler<UserPhotoUploadEventArgs> UploadTrollPhoto;

        protected string SuccessMessage { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = this.Page.User.Identity.GetUserId();
            this.GetUser?.Invoke(this, new UserIdEventArgs(id));

            if (this.Model.User.AvatarPath != null)
            {
                this.UserAvatar.ImageUrl = this.Model.User.AvatarPath;
            }
            else
            {
                this.UserAvatar.ImageUrl = DefaultAvatarPath;
            }
        }

        protected void UploadTrollPhotoButton_Click(object sender, EventArgs e)
        {
            if (this.TrollPhotoFileUpload.HasFiles)
            {
                HttpPostedFile postedFile = this.TrollPhotoFileUpload.PostedFile;
                string extension = Path.GetExtension(postedFile.FileName);
                string defaultTrollPhotoName = $"photo-by-{this.User.Identity.Name}.{extension}";

                HttpPostedFileBase fileBase = new HttpPostedFileWrapper(postedFile);

                string trollPhotoName = this.TrollPhotoNameTextBox.Text + extension;
                string filename = this.TrollPhotoNameTextBox.Text != string.Empty ? trollPhotoName : defaultTrollPhotoName;
                string filePath = "/photos/TrollPhotos/" + filename;
                string storageLocation = Server.MapPath($"~{filePath}");

                this.UploadTrollPhoto?.Invoke(this, new UserPhotoUploadEventArgs(
                    fileBase,
                    filePath,
                    storageLocation,
                    this.User.Identity.GetUserId()));
            }

            if (this.Model.TrollPhotoIsUploaded)
            {
                    this.successMessage.Visible = true;
                    this.SuccessMessage = "Your photo has been added.";
            }
            else
            {
                this.successMessage.Visible = false; ;
                this.SuccessMessage = "There was a problem uploading your photo.";
            }
        }
    }
}