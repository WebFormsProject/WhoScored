using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using WebFormsMvp;
using WhoScored.Models.Models;
using WhoScored.MVP.Identity;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Views.Auth;
using WhoScored.Services.Contracts;
using System;

namespace WhoScored.MVP.Presenters.Auth
{
    public class RegisterPresenter : Presenter<IRegisterView>
    {
        private const int MaxAvatarSizeInBytes = 10 * 1000 * 1000;

        private readonly IUserService userAvatarService;

        public RegisterPresenter(IUserService userAvatarService, IRegisterView view)
            : base(view)
        {
            Guard.WhenArgument(userAvatarService, "userAvatarService").IsNull().Throw();

            this.userAvatarService = userAvatarService;

            this.View.Registering += this.View_OnRegistering;
        }

        private void View_OnRegistering(object sender, RegisterEventArgs e)
        {
            ApplicationUserManager manager = e.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationSignInManager signInManager = e.HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            User user = new User()
            {
                UserName = e.Username,
                Email = e.Email,
                FirstName = e.FirstName,
                LastName = e.LastName,
                AvatarPath = e.AvatarFilePath
            };

            IdentityResult result = manager.Create(user, e.Password);
            if (result.Succeeded)
            {
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
            }

            HttpPostedFileBase uploadedFile = e.AvatarFileBase;
            if (uploadedFile != null && uploadedFile.ContentLength <= MaxAvatarSizeInBytes)
            {
                uploadedFile.SaveAs(e.AvatarStorageLocation);
                this.userAvatarService.UploadAvatar(user.Id, e.AvatarFilePath);
            }

            this.View.Model.IdentityResult = result;
        }
    }
}
