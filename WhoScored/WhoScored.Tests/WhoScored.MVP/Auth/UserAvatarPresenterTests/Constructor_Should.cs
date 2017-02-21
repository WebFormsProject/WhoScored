using System;
using Moq;
using NUnit.Framework;
using WhoScored.Services.Contracts;
using WhoScored.MVP.Presenters.Auth;
using WhoScored.MVP.Views.Auth;

namespace WhoScored.Tests.WhoScored.MVP.Auth.UserAvatarPresenterTests
{
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIUserAvatarServiceIsNull()
        {
            var viewMock = new Mock<IUserAvatarView>();

            var exception = Assert.Throws<ArgumentNullException>(() => new UserAvatarPresenter(null, viewMock.Object));

            StringAssert.IsMatch("userService", exception.ParamName);
        }

        [Test]
        public void CreateInstance_WhenParametersAreValid()
        {
            var viewMock = new Mock<IUserAvatarView>();
            var userAvatarServiceMock = new Mock<IUserService>();

            UserAvatarPresenter presenter = new UserAvatarPresenter(userAvatarServiceMock.Object, viewMock.Object);

            Assert.IsInstanceOf<UserAvatarPresenter>(presenter);
        }
    }
}
