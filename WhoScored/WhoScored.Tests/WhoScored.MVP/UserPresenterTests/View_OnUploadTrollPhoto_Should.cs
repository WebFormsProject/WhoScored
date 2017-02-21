using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
    public class View_OnUploadTrollPhoto_Should
    {
        [Test]
        public void CallSaveAsOnce_WhenOnUploadTrollPhotoIsRaised()
        {
            var viewMock = new Mock<IUserView>();
            var userService = new Mock<IUserService>();
            var trollPhotoService = new Mock<ITrollPhotoService>();
            var mockedUploadedFile = new Mock<HttpPostedFileBase>();
            string filePath = "path";
            string storageLocation = "storageLocation";
            string userId = "id";

            UserViewModel model = new UserViewModel();
            viewMock.Setup(x => x.Model).Returns(model);

            UserPresenter presenter = new UserPresenter(viewMock.Object, userService.Object, trollPhotoService.Object);

            viewMock.Raise(x => x.UploadTrollPhoto += null,
                new UserPhotoUploadEventArgs(mockedUploadedFile.Object, filePath, storageLocation, userId));

            mockedUploadedFile.Verify(x => x.SaveAs(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void CallUploadTrollPhotoOnce_WhenOnUploadTrollPhotoIsRaised()
        {
            var viewMock = new Mock<IUserView>();
            var userService = new Mock<IUserService>();
            var trollPhotoService = new Mock<ITrollPhotoService>();
            var mockedUploadedFile = new Mock<HttpPostedFileBase>();
            string filePath = "path";
            string storageLocation = "storageLocation";
            string userId = "id";

            UserViewModel model = new UserViewModel();
            viewMock.Setup(x => x.Model).Returns(model);

            UserPresenter presenter = new UserPresenter(viewMock.Object, userService.Object, trollPhotoService.Object);

            viewMock.Raise(x => x.UploadTrollPhoto += null,
                new UserPhotoUploadEventArgs(mockedUploadedFile.Object, filePath, storageLocation, userId));

            trollPhotoService.Verify(x => x.UploadTrollPhoto(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void MarkTrollPhotoIsUploadedAsTrue_WhenOnUploadTrollPhotoIsRaised()
        {
            var viewMock = new Mock<IUserView>();
            var userService = new Mock<IUserService>();
            var trollPhotoService = new Mock<ITrollPhotoService>();
            var mockedUploadedFile = new Mock<HttpPostedFileBase>();
            string filePath = "path";
            string storageLocation = "storageLocation";
            string userId = "id";

            UserViewModel model = new UserViewModel();
            viewMock.Setup(x => x.Model).Returns(model);

            UserPresenter presenter = new UserPresenter(viewMock.Object, userService.Object, trollPhotoService.Object);

            viewMock.Raise(x => x.UploadTrollPhoto += null,
                new UserPhotoUploadEventArgs(mockedUploadedFile.Object, filePath, storageLocation, userId));

            Assert.IsTrue(viewMock.Object.Model.TrollPhotoIsUploaded);
        }
    }
}
