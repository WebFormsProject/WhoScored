﻿using Bytes2you.Validation;
using WebFormsMvp;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.WebFormsClient.Models.CustomEvents;
using WhoScored.WebFormsClient.Views;

namespace WhoScored.WebFormsClient.Presenters
{
    public class UserPresenter : Presenter<IUserView>
    {
        private readonly IWhoScoredRepository<User> usersRepository;
    

        public UserPresenter(IUserView view, IWhoScoredRepository<User> usersRepository)
            : base(view)
        {
            Guard.WhenArgument(usersRepository, "usersRepository").IsNull().Throw();
            this.usersRepository = usersRepository;

            this.View.OnGetUser += this.View_GetUser;
        }

        private void View_GetUser(object sender, UserIdEventArgs e)
        {
            this.View.Model.User = this.usersRepository.GetById(e.Id);
        }
    }
}