using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.UserServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIdIsNull()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepository = new Mock<IWhoScoredRepository<User>>();

            IUserService userService = new UserService(mockedUnitOfWork.Object, mockedRepository.Object);

            var actualException = Assert.Throws<ArgumentNullException>(() => userService.GetUserById(null));

            StringAssert.IsMatch("userId", actualException.ParamName);
        }

        [Test]
        public void ReturnNull_WhenUserWithSuchIdDoesNotExist()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepository = new Mock<IWhoScoredRepository<User>>();

            IUserService userService = new UserService(mockedUnitOfWork.Object, mockedRepository.Object);
            var actualUser = userService.GetUserById(1);

            Assert.AreSame(null, actualUser);
        }

        [Test]
        public void ReturnCorrectUser_WhenIdIsValid()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepository = new Mock<IWhoScoredRepository<User>>();
            int userId = 5;
            User expectedUser = new User();

            IUserService userService = new UserService(mockedUnitOfWork.Object, mockedRepository.Object);

            mockedRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(expectedUser);
            var actualUser = userService.GetUserById(userId);

            Assert.AreSame(expectedUser, actualUser);
        }

        [Test]
        public void CallRepositoryGetByIdOnce_WhenIdIsValid()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepository = new Mock<IWhoScoredRepository<User>>();
            int userId = 5;

            IUserService userService = new UserService(mockedUnitOfWork.Object, mockedRepository.Object);
            userService.GetUserById(userId);

            mockedRepository.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }
    }
}
