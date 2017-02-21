using System;
using System.Collections.Generic;
using System.Linq;
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
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIUnitOfWorkArgumentIsNull()
        {
            var mockedRepository = new Mock<IWhoScoredRepository<User>>();

            var actualException = Assert.Throws<ArgumentNullException>(() => new UserService(null, mockedRepository.Object));

            StringAssert.IsMatch("unitOfWork", actualException.ParamName);
        }

        [Test]
        public void ThrowArgumentNullException_WhenIIWhoScoredRepositoryArgumentIsNull()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var actualException = Assert.Throws<ArgumentNullException>(() => new UserService(mockedUnitOfWork.Object, null));

            StringAssert.IsMatch("userRepository", actualException.ParamName);
        }

        [Test]
        public void ReturnCorrectInstance_WhenArgumentsAreValid()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepository = new Mock<IWhoScoredRepository<User>>();

            IUserService userService = new UserService(mockedUnitOfWork.Object, mockedRepository.Object);

            Assert.IsInstanceOf(typeof(UserService), userService);
        }
    }
}
