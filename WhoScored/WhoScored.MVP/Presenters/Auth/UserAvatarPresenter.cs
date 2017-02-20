using Bytes2you.Validation;
using WebFormsMvp;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Views.Auth;
using WhoScored.Services.Contracts;

namespace WhoScored.MVP.Presenters.Auth
{
    public class UserAvatarPresenter : Presenter<IUserAvatarView>
    {
        private readonly IUserAvatarService userAvatarService;

        public UserAvatarPresenter(IUserAvatarService userAvatarService, IUserAvatarView view)
            : base(view)
        {
            Guard.WhenArgument(userAvatarService, "userAvatarService").IsNull().Throw();

            this.userAvatarService = userAvatarService;

            this.View.GetAvatar += this.View_GetAvatar;
            this.View.UploadAvatar += this.View_UploadAvatar;
        }

        private void View_GetAvatar(object sender, UserIdEventArgs e)
        {
            this.View.Model.UserAvatarUrl = this.userAvatarService.GetAvatarFilePath(e.Id);
        }

        private void View_UploadAvatar(object sender, UserAvatarEventArgs e)
        {
            var uploadedFile = e.PostedFileBase;

            // TODO: check content type and size
            uploadedFile.SaveAs(e.AvatarStorageLocation);
            this.userAvatarService.UploadAvatar(e.UserId, e.AvatarFilePath);
        }
    }
}
