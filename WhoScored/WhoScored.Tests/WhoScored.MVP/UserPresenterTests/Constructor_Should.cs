using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.MVP.UserPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIUserServiceIsNull()
        {
            var viewMock = new Mock<IUserView>();
            var trollPhotoService = new Mock<ITrollPhotoService>();

            var exception = Assert.Throws<ArgumentNullException>(() => new UserPresenter(viewMock.Object, null, trollPhotoService.Object));

            StringAssert.IsMatch("userService", exception.ParamName);
        }

        [Test]
        public void ThrowArgumentNullException_WhenITrollPhotoServiceIsNull()
        {
            var viewMock = new Mock<IUserView>();
            var userService = new Mock<IUserService>();

            var exception = Assert.Throws<ArgumentNullException>(() => new UserPresenter(viewMock.Object, userService.Object, null));

            StringAssert.IsMatch("trollPhotoService", exception.ParamName);
        }

        [Test]
        public void CreateInstance_WhenParametersAreValid()
        {
            var viewMock = new Mock<IUserView>();
            var userService = new Mock<IUserService>();
            var trollPhotoService = new Mock<ITrollPhotoService>();

            UserPresenter presenter = new UserPresenter(viewMock.Object, userService.Object, trollPhotoService.Object);

            Assert.IsInstanceOf<UserPresenter>(presenter);
        }
    }
}
