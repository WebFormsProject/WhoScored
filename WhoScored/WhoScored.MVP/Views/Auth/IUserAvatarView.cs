using System;
using WebFormsMvp;
using WhoScored.MVP.Models.Auth;
using WhoScored.MVP.Models.CustomEventArgs;

namespace WhoScored.MVP.Views.Auth
{
    public interface IUserAvatarView : IView<UserAvatarViewModelcs>
    {
        event EventHandler<UserIdEventArgs> GetAvatar;

        event EventHandler<UserAvatarEventArgs> UploadAvatar;
    }
}
