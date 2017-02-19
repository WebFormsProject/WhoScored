using Microsoft.AspNet.Identity;
using System;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhoScored.MVP.Models;
using WhoScored.MVP.Models.CustomEvents;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;

namespace WhoScored.WebFormsClient
{
    [PresenterBinding(typeof(UserPresenter))]
    public partial class Profile : MvpPage<UserViewModel>, IUserView
    {
        public event EventHandler<UserIdEventArgs> OnGetUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = this.Page.User.Identity.GetUserId();

            this.OnGetUser?.Invoke(this, new UserIdEventArgs(id));

            this.UserAvatar.ImageUrl = this.Model.User.AvatarPath = "/photos/Avatars/pepsi.jpg";
            this.UserLabel.Text = $"{this.Model.User.FirstName} {this.Model.User.LastName}";
            this.DataBind();
        }

        //protected void TrollPhotoFileUpload_DataBinding(object sender, EventArgs e)
        //{
        //}
    }
}