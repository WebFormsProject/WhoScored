﻿using System;
using WebFormsMvp;
using WhoScored.MVP.Models.Auth;
using WhoScored.MVP.Models.CustomEventArgs;

namespace WhoScored.MVP.Views.Auth
{
    public interface IPasswordChangeView : IView<PasswordChangeViewModel>
    {
        event EventHandler<PasswordChangeEventArgs> ChangePassword;
    }
}
