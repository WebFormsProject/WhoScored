using Bytes2you.Validation;
using System.Web;
using WebFormsMvp;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Views.Auth;
using WhoScored.Services.Contracts;

namespace WhoScored.MVP.Presenters.Auth
{
    public class UserAvatarPresenter : Presenter<IUserAvatarView>
    {
        private const int MaxAvatarSizeInBytes = 10 * 1000 * 1000;

        private readonly IUserService userService;

        public UserAvatarPresenter(IUserService userService, IUserAvatarView view)
            : base(view)
        {
            Guard.WhenArgument(userService, "userService").IsNull().Throw();

            this.userService = userService;

            this.View.GetAvatar += this.View_GetAvatar;
            this.View.UploadAvatar += this.View_UploadAvatar;
        }

        private void View_GetAvatar(object sender, UserIdEventArgs e)
        {
            this.View.Model.PhotoFilePath = this.userService.GetAvatarFilePath(e.Id);
        }

        private void View_UploadAvatar(object sender, UserPhotoUploadEventArgs e)
        {
            HttpPostedFileBase uploadedFile = e.PostedFileBase;
            if (uploadedFile.ContentLength <= MaxAvatarSizeInBytes)
            {
                uploadedFile.SaveAs(e.StorageLocation);

                this.userService.UploadAvatar(e.UserId, e.FilePath);
                this.View.Model.PhotoIsUploaded = true;
            }
        }
    }
}
