using System;
using WebFormsMvp;
using WhoScored.WebFormsClient.Models;

namespace WhoScored.WebFormsClient.Views
{
    public interface ITrollPhotosView : IView<TrollPhotosViewMode>
    {
        event EventHandler GetTrollPhotos;
    }
}
