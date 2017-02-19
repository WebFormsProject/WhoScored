using System;
using System.Linq;
using Bytes2you.Validation;
using WebFormsMvp;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.MVP.Views;

namespace WhoScored.MVP.Presenters
{
    public class TrollPhotosPresenter : Presenter<ITrollPhotosView>
    {
        private readonly IWhoScoredRepository<TrollPhoto> trollPhotosRepository;

        public TrollPhotosPresenter(ITrollPhotosView view, IWhoScoredRepository<TrollPhoto> trollPhotosRepository)
            : base(view)
        {
            Guard.WhenArgument(trollPhotosRepository, "trollPhotosRepository").IsNull().Throw();
            this.trollPhotosRepository = trollPhotosRepository;

            this.View.OnGetTrollPhotosPaths += this.View_GetTrollPhotos;
        }

        private void View_GetTrollPhotos(object sender, EventArgs e)
        {
            this.View.Model.TrollPhotosPaths = this.trollPhotosRepository.GetAll().Select(p => p.PhotoPath);
        }
    }
}