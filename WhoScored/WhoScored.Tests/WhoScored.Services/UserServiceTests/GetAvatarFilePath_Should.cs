using System;
using Moq;
using NUnit.Framework;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.UserServiceTests
{
    [TestFixture]
    public class GetAvatarFilePath_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenUserIdIsNull()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepository = new Mock<IWhoScoredRepository<User>>();

            IUserService userService = new UserService(mockedUnitOfWork.Object, mockedRepository.Object);

            var actualException = Assert.Throws<ArgumentNullException>(() => userService.GetAvatarFilePath(null));

            StringAssert.IsMatch("userId", actualException.ParamName);
        }

        [Test]
        public void ReturnCorrectImagePath_WhenUserIdIsValid()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepository = new Mock<IWhoScoredRepository<User>>();

            string path = "some-path.jpg";
            string userId = "user-id";
            User user = new User() { AvatarPath = path };

            IUserService userService = new UserService(mockedUnitOfWork.Object, mockedRepository.Object);
            mockedRepository.Setup(x => x.GetById(userId)).Returns(user);

            string actualPath = userService.GetAvatarFilePath(userId);

            Assert.AreSame(path, actualPath);
        }

        [Test]
        public void ReturnNull_WhenUserWithSuchIdDoesNotExist()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepository = new Mock<IWhoScoredRepository<User>>();

            IUserService userService = new UserService(mockedUnitOfWork.Object, mockedRepository.Object);

            string actualPath = userService.GetAvatarFilePath("id");
            Assert.AreSame(null, actualPath);
        }

        [Test]
        public void CallRepositoryGetByIdOnce_WhenUserIdIsValid()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepository = new Mock<IWhoScoredRepository<User>>();

            string userId = "user-id";
            User user = new User();

            IUserService userService = new UserService(mockedUnitOfWork.Object, mockedRepository.Object);
            mockedRepository.Setup(x => x.GetById(userId)).Returns(user);

            userService.GetAvatarFilePath(userId);

            mockedRepository.Verify(x=>x.GetById(It.IsAny<string>()), Times.Once);
        }
    }
}
