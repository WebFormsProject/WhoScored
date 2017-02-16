using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhoScored.WebFormsClient.Models;
using WhoScored.WebFormsClient.Presenters;
using WhoScored.WebFormsClient.Services;
using WhoScored.WebFormsClient.Views;

namespace WhoScored.WebFormsClient
{
    [PresenterBinding(typeof(TrollPhotosPresenter))]
    public partial class TrollPhotos : MvpPage<TrollPhotosViewMode>, ITrollPhotosView
    {
        private static int selectedImageIndex;
        private static IList<string> imagesPaths;

        public event EventHandler GetTrollPhotos;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (imagesPaths == null || this.SelectedImage.ImageUrl == null)
            {
                this.GetTrollPhotos?.Invoke(sender, e);

                imagesPaths = this.Model.TrollPhotosPaths.ToList();
                selectedImageIndex = 1;
            }

            this.SelectedImage.ImageUrl = imagesPaths[selectedImageIndex];
        }

        protected void ButtonPrevious_Click(object sender, EventArgs e)
        {
            if ((selectedImageIndex - 1) < 0)
            {
                selectedImageIndex = imagesPaths.Count;
            }

            selectedImageIndex--;
            this.SelectedImage.ImageUrl = imagesPaths[selectedImageIndex];
        }

        protected void ButtonNext_Click(object sender, EventArgs e)
        {
            selectedImageIndex = (selectedImageIndex + 1) % imagesPaths.Count;
            this.SelectedImage.ImageUrl = imagesPaths[selectedImageIndex];
        }
    }
}