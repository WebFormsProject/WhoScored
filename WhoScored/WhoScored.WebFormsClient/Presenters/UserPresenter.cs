using Bytes2you.Validation;
using System.Web.Providers.Entities;
using WebFormsMvp;
using WhoScored.Data.Contracts;
using WhoScored.WebFormsClient.Models.CustomEvents;
using WhoScored.WebFormsClient.Views;

namespace WhoScored.WebFormsClient.Presenters
{
    public class UserPresenter : Presenter<IUserView>
    {
        // private readonly IWhoScoredRepository<User> usersRepository;

        // Removed injected IWhoScoredRepository<User> usersRepository because of the error
        public UserPresenter(IUserView view)
            : base(view)
        {
           // Guard.WhenArgument(usersRepository, "usersRepository").IsNull().Throw();
           // this.usersRepository = usersRepository;

            this.View.OnGetUser += this.View_GetUser;
        }

        private void View_GetUser(object sender, IdEventArgs e)
        {
            // this.View.Model.User = this.usersRepository.GetById(e.Id);
        }
    }
}