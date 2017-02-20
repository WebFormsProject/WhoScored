using System;
using Bytes2you.Validation;
using WebFormsMvp;
using WhoScored.MVP.Views;
using WhoScored.Services.Contracts;

namespace WhoScored.MVP.Presenters
{
    public class TrollPhotosPresenter : Presenter<ITrollPhotosView>
    {
        private readonly ITrollPhotoService trollPhotoService;

        public TrollPhotosPresenter(ITrollPhotosView view, ITrollPhotoService trollPhotoService)
            : base(view)
        {
            Guard.WhenArgument(trollPhotoService, "trollPhotoService").IsNull().Throw();
            this.trollPhotoService = trollPhotoService;

            this.View.OnGetTrollPhotosPaths += this.View_GetTrollPhotos;
        }

        private void View_GetTrollPhotos(object sender, EventArgs e)
        {
            this.View.Model.TrollPhotosPaths = this.trollPhotoService.GetTrollPhotoPaths();
        }
    }
}