using System;
using System.Web;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhoScored.WebFormsClient.Models;
using WhoScored.WebFormsClient.Models.CustomEvents;
using WhoScored.WebFormsClient.Presenters;
using WhoScored.WebFormsClient.Views;

namespace WhoScored.WebFormsClient
{
    [PresenterBinding(typeof(UserPresenter))]
    public partial class Profile : MvpPage<UserViewModel>, IUserView
    {
        public event EventHandler<IdEventArgs> OnGetUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.OnGetUser?.Invoke(this, new IdEventArgs(id));

            //this.ListViewProfile.DataSource = this.Model.User;
            //this.ListViewProfile.DataBind();
        }
    }
}