using System;
using WebFormsMvp;
using WhoScored.MVP.Models;

namespace WhoScored.MVP.Views
{
    public interface ITrollPhotosView : IView<TrollPhotosViewModel>
    {
        event EventHandler OnGetTrollPhotosPaths;
    }
}
