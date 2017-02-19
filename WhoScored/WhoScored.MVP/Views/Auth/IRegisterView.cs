using System;
using WebFormsMvp;
using WhoScored.MVP.Models.Auth;
using WhoScored.MVP.Models.CustomEvents;

namespace WhoScored.MVP.Views.Auth
{
    public interface IRegisterView : IView<RegisterViewModel>
    {
        event EventHandler<RegisterEventArgs> Registering;
    }
}
