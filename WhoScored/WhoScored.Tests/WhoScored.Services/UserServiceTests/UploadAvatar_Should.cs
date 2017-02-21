using System;
using Moq;
using NUnit.Framework;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.UserServiceTests
{
    public class UploadAvatar_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenUserIdIsNull()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepository = new Mock<IWhoScoredRepository<User>>();

            IUserService userService = new UserService(mockedUnitOfWork.Object, mockedRepository.Object);

            var actualException = Assert.Throws<ArgumentNullException>(() => userService.UploadAvatar(null, "path"));

            StringAssert.IsMatch("userId", actualException.ParamName);
        }

        [Test]
        public void ThrowArgumentNullException_WhenFilePathIsNull()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepository = new Mock<IWhoScoredRepository<User>>();

            IUserService userService = new UserService(mockedUnitOfWork.Object, mockedRepository.Object);

            var actualException = Assert.Throws<ArgumentNullException>(() => userService.UploadAvatar("id", null));

            StringAssert.IsMatch("filePath", actualException.ParamName);
        }

        [Test]
        public void ShouldChangeAvatarPath_WhenArgumentsAreValid()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepository = new Mock<IWhoScoredRepository<User>>();

            string userId = "id";
            string newAvatarPath = "new-avatar";
            User user = new User() { Id = userId, AvatarPath = "old-path"};
            mockedRepository.Setup(x => x.GetById(It.IsAny<string>())).Returns(user);

            IUserService userService = new UserService(mockedUnitOfWork.Object, mockedRepository.Object);
            userService.UploadAvatar(userId, newAvatarPath);

            Assert.AreSame(newAvatarPath, user.AvatarPath);
        }

        [Test]
        public void ShouldCallGetUserByIdOnce_WhenArgumentsAreValid()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepository = new Mock<IWhoScoredRepository<User>>();

            IUserService userService = new UserService(mockedUnitOfWork.Object, mockedRepository.Object);
            userService.UploadAvatar("id", "path");

            mockedRepository.Verify(x => x.GetById(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ShouldCallCommitOnce_WhenArgumentsAreValid()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepository = new Mock<IWhoScoredRepository<User>>();

            User user = new User() { Id = "id" };
            mockedRepository.Setup(x => x.GetById(It.IsAny<string>())).Returns(user);

            IUserService userService = new UserService(mockedUnitOfWork.Object, mockedRepository.Object);
            userService.UploadAvatar("id", "path");

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void ShouldNeverCallCommit_WhenUserIdIsNotFound()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepository = new Mock<IWhoScoredRepository<User>>();

            IUserService userService = new UserService(mockedUnitOfWork.Object, mockedRepository.Object);
            userService.UploadAvatar("id", "path");

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Never);
        }
    }
}
