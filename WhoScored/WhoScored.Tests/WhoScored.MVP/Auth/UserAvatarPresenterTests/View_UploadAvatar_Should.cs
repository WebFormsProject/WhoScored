using Moq;
using NUnit.Framework;
using WhoScored.Services.Contracts;
using WhoScored.MVP.Presenters.Auth;
using WhoScored.MVP.Views.Auth;
using WhoScored.MVP.Models.Auth;
using WhoScored.MVP.Models.CustomEventArgs;
using System.Web;

namespace WhoScored.Tests.WhoScored.MVP.Auth.UserAvatarPresenterTests
{
    class View_UploadAvatar_Should
    {
        private const int MaxAvatarSizeInBytes = 10 * 1000 * 1000;

        [TestCase(0)]
        [TestCase(MaxAvatarSizeInBytes)]
        public void CallSaveAsOnce_WhenUploadAvatarIsRaised_AndUploadedFileContentLengthIsValid(int validContentLength)
        {
            var viewMock = new Mock<IUserAvatarView>();
            var userService = new Mock<IUserService>();
            var mockedUploadedFile = new Mock<HttpPostedFileBase>();

            string filePath = "path";
            string storageLocation = "storageLocation";
            string userId = "id";

            mockedUploadedFile.Setup(x => x.ContentLength).Returns(validContentLength);
            viewMock.Setup(x => x.Model).Returns(new UserUploadPhotoViewModel());

            UserAvatarPresenter presenter = new UserAvatarPresenter(userService.Object, viewMock.Object);

            viewMock.Raise(x => x.UploadAvatar += null,
                new UserPhotoUploadEventArgs(mockedUploadedFile.Object, filePath, storageLocation, userId));

            mockedUploadedFile.Verify(x => x.SaveAs(It.IsAny<string>()), Times.Once);
        }

        [TestCase]
        public void NeverCallSaveAs_WhenUploadedFileContentLengthIsNotValid()
        {
            var viewMock = new Mock<IUserAvatarView>();
            var userService = new Mock<IUserService>();
            var mockedUploadedFile = new Mock<HttpPostedFileBase>();
            string filePath = "path";
            string storageLocation = "storageLocation";
            string userId = "id";

            mockedUploadedFile.Setup(x => x.ContentLength).Returns(MaxAvatarSizeInBytes + 1);
            viewMock.Setup(x => x.Model).Returns(new UserUploadPhotoViewModel());

            UserAvatarPresenter presenter = new UserAvatarPresenter(userService.Object, viewMock.Object);

            viewMock.Raise(x => x.UploadAvatar += null,
                new UserPhotoUploadEventArgs(mockedUploadedFile.Object, filePath, storageLocation, userId));

            mockedUploadedFile.Verify(x => x.SaveAs(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void CallServiceMethodOnce_WhenOnUploadAvatarIsRaised_AndUploadedFileContentLengtIsValid()
        {
            var viewMock = new Mock<IUserAvatarView>();
            var userService = new Mock<IUserService>();
            var mockedUploadedFile = new Mock<HttpPostedFileBase>();
            string filePath = "path";
            string storageLocation = "storageLocation";
            string userId = "id";

            mockedUploadedFile.Setup(x => x.ContentLength).Returns(MaxAvatarSizeInBytes);
            viewMock.Setup(x => x.Model).Returns(new UserUploadPhotoViewModel());

            UserAvatarPresenter presenter = new UserAvatarPresenter(userService.Object, viewMock.Object);

            viewMock.Raise(x => x.UploadAvatar += null,
                new UserPhotoUploadEventArgs(mockedUploadedFile.Object, filePath, storageLocation, userId));

            userService.Verify(x => x.UploadAvatar(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void NeverCallServiceMethod_WhenUploadedFileContentLengtIsValid()
        {
            var viewMock = new Mock<IUserAvatarView>();
            var userService = new Mock<IUserService>();
            var mockedUploadedFile = new Mock<HttpPostedFileBase>();
            string filePath = "path";
            string storageLocation = "storageLocation";
            string userId = "id";

            mockedUploadedFile.Setup(x => x.ContentLength).Returns(MaxAvatarSizeInBytes + 1);
            viewMock.Setup(x => x.Model).Returns(new UserUploadPhotoViewModel());

            UserAvatarPresenter presenter = new UserAvatarPresenter(userService.Object, viewMock.Object);

            viewMock.Raise(x => x.UploadAvatar += null,
                new UserPhotoUploadEventArgs(mockedUploadedFile.Object, filePath, storageLocation, userId));

            userService.Verify(x => x.UploadAvatar(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void MarkAvatarIsUploadedAsTrue_WhenOnUploadAvatarIsRaised_AndUploadedFileContentLengtIsValid()
        {
            var viewMock = new Mock<IUserAvatarView>();
            var userService = new Mock<IUserService>();
            var mockedUploadedFile = new Mock<HttpPostedFileBase>();
            string filePath = "path";
            string storageLocation = "storageLocation";
            string userId = "id";

            mockedUploadedFile.Setup(x => x.ContentLength).Returns(MaxAvatarSizeInBytes);
            viewMock.Setup(x => x.Model).Returns(new UserUploadPhotoViewModel());

            UserAvatarPresenter presenter = new UserAvatarPresenter(userService.Object, viewMock.Object);

            viewMock.Raise(x => x.UploadAvatar += null,
                new UserPhotoUploadEventArgs(mockedUploadedFile.Object, filePath, storageLocation, userId));

            Assert.IsTrue(viewMock.Object.Model.PhotoIsUploaded);
        }

        [Test]
        public void MarkAvatarIsUploadedAsFalse_WhenUploadedFileContentLengtIsNotValid()
        {
            var viewMock = new Mock<IUserAvatarView>();
            var userService = new Mock<IUserService>();
            var mockedUploadedFile = new Mock<HttpPostedFileBase>();
            string filePath = "path";
            string storageLocation = "storageLocation";
            string userId = "id";

            mockedUploadedFile.Setup(x => x.ContentLength).Returns(MaxAvatarSizeInBytes + 1);
            viewMock.Setup(x => x.Model).Returns(new UserUploadPhotoViewModel());

            UserAvatarPresenter presenter = new UserAvatarPresenter(userService.Object, viewMock.Object);

            viewMock.Raise(x => x.UploadAvatar += null,
                new UserPhotoUploadEventArgs(mockedUploadedFile.Object, filePath, storageLocation, userId));

            Assert.IsFalse(viewMock.Object.Model.PhotoIsUploaded);
        }
    }
}
