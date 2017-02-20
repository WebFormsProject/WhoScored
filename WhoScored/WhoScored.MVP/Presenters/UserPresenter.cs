using Bytes2you.Validation;
using WebFormsMvp;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Views;
using WhoScored.Services.Contracts;
using System.Web;

namespace WhoScored.MVP.Presenters
{
    public class UserPresenter : Presenter<IUserView>
    {
        private readonly IUserService userService;
        private readonly ITrollPhotoService trollPhotoService;

        public UserPresenter(IUserView view, IUserService userService, ITrollPhotoService trollPhotoService)
            : base(view)
        {
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(trollPhotoService, "trollPhotoService").IsNull().Throw();
            this.userService = userService;
            this.trollPhotoService = trollPhotoService;

            this.View.GetUser += this.View_GetUser;
            this.View.UploadTrollPhoto += this.View_UploadTrollPhoto;
        }

        private void View_GetUser(object sender, UserIdEventArgs e)
        {
            this.View.Model.User = this.userService.GetUserById(e.Id);
        }

        private void View_UploadTrollPhoto(object sender, UserPhotoUploadEventArgs e)
        {
            HttpPostedFileBase uploadedFile = e.PostedFileBase;
            uploadedFile.SaveAs(e.StorageLocation);

            this.trollPhotoService.UploadTrollPhoto(e.UserId, e.FilePath);
            this.View.Model.TrollPhotoIsUploaded = true;
        }
    }
}