using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WhoScored.Models.Models;
using WhoScored.MVP.Models;
using WhoScored.MVP.Models.CustomEventArgs;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.MVP.UserPresenterTests
{
    [TestFixture]
    public class View_OnGetUser_Should
    {
        [Test]
        public void AppendGetUserToViewModel_WhenOnViewGetUserIsRaised()
        {
            var viewMock = new Mock<IUserView>();
            var userService = new Mock<IUserService>();
            var trollPhotoService = new Mock<ITrollPhotoService>();
            string id = "id";
            User user = new User() {Id = id};
            userService.Setup(x => x.GetUserById(It.IsAny<string>())).Returns(user);

            UserViewModel model = new UserViewModel();
            viewMock.Setup(x => x.Model).Returns(model);

            UserPresenter presenter = new UserPresenter(viewMock.Object, userService.Object, trollPhotoService.Object);

            viewMock.Raise(x=>x.GetUser += null, new UserIdEventArgs(id));

            Assert.AreSame(user, viewMock.Object.Model.User);
        }
    }
}
