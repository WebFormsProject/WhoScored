using Bytes2you.Validation;
using WebFormsMvp;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Views;
using WhoScored.Services.Contracts;

namespace WhoScored.MVP.Presenters
{
    public class UserPresenter : Presenter<IUserView>
    {
        private readonly IUserService userService;
    

        public UserPresenter(IUserView view, IUserService userService)
            : base(view)
        {
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            this.userService = userService;

            this.View.OnGetUser += this.View_GetUser;
        }

        private void View_GetUser(object sender, UserIdEventArgs e)
        {
            this.View.Model.User = this.userService.GetUserById(e.Id);
        }
    }
}