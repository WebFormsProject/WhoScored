using System;
using WebFormsMvp;
using WhoScored.WebFormsClient.Models;
using WhoScored.WebFormsClient.Models.CustomEvents;

namespace WhoScored.WebFormsClient.Views
{
    public interface IUserView : IView<UserViewModel>
    {
        event EventHandler<UserIdEventArgs> OnGetUser;
    }
}
