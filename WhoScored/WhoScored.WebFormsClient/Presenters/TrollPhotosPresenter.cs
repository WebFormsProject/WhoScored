using Bytes2you.Validation;
using System;
using WebFormsMvp;
using WhoScored.WebFormsClient.Services.Contracts;
using WhoScored.WebFormsClient.Views;

namespace WhoScored.WebFormsClient.Presenters
{
    public class TrollPhotosPresenter : Presenter<ITrollPhotosView>
    {
        private readonly ITrollPhotosService trollPhotosService;

        private const string TrollPhotosDirectory = "~/photos/";

        public TrollPhotosPresenter(ITrollPhotosView view, ITrollPhotosService trollPhotosService)
            : base(view)
        {
            Guard.WhenArgument(this.trollPhotosService, "trollPhotosService").IsNull();
            this.trollPhotosService = trollPhotosService;

            this.View.GetTrollPhotos += this.View_GetTrollPhotos;
        }

        private void View_GetTrollPhotos(object sender, EventArgs e)
        {
            this.View.Model.TrollPhotosPaths = this.trollPhotosService.GetImages(TrollPhotosDirectory);
        }
    }
}