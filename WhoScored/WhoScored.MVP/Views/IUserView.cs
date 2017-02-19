using System;
using WebFormsMvp;
using WhoScored.MVP.Models;
using WhoScored.MVP.Models.CustomEvents;

namespace WhoScored.MVP.Views
{
    public interface IUserView : IView<UserViewModel>
    {
        event EventHandler<UserIdEventArgs> OnGetUser;
    }
}
