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
    public class UploadAvatar_Should
    {
        public void ThrowArgumentNullException_WhenUserIdIsNull()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepository = new Mock<IWhoScoredRepository<User>>();

            IUserService userService = new UserService(mockedUnitOfWork.Object, mockedRepository.Object);

            var actualException = Assert.Throws<ArgumentNullException>(() => userService.UploadAvatar(null, "path"));

            StringAssert.IsMatch("userId", actualException.ParamName);
        }

        public void ThrowArgumentNullException_WhenFilePathIsNull()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepository = new Mock<IWhoScoredRepository<User>>();

            IUserService userService = new UserService(mockedUnitOfWork.Object, mockedRepository.Object);

            var actualException = Assert.Throws<ArgumentNullException>(() => userService.UploadAvatar("id", null));

            StringAssert.IsMatch("filePath", actualException.ParamName);
        }
    }
}
