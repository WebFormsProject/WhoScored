using System;
using System.Collections.Generic;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhoScored.MVP.Models;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;


namespace WhoScored.WebFormsClient
{
    [PresenterBinding(typeof(TrollPhotosPresenter))]
    public partial class TrollPhotos : MvpPage<TrollPhotosViewModel>, ITrollPhotosView
    {
        private static int selectedImageIndex;
        private static IList<string> imagesPaths;

        private string[] ImageExtensions = new string[] { ".jpg", ".png" };

        public event EventHandler OnGetTrollPhotosPaths;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (imagesPaths == null || this.SelectedImage.ImageUrl == null)
            {
                this.OnGetTrollPhotosPaths?.Invoke(this, null);

                selectedImageIndex = 1;
                imagesPaths = this.Model.TrollPhotosPaths
                    .Where(photo => photo.EndsWith(ImageExtensions[0]) || photo.EndsWith(ImageExtensions[1]))
                    .ToList();
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