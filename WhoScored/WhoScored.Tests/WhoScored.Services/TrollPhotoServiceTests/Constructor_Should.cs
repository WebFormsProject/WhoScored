using NUnit.Framework;
using System;
using Moq;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.TrollPhotoServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedRepositoryIsNull()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var actualMessage = Assert.Throws<ArgumentNullException>(() => new TrollPhotoService(unitOfWorkMock.Object, null));

            StringAssert.IsMatch("trollPhotoRepository", actualMessage.ParamName);
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedUnitOfWorkIsNull()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<TrollPhoto>>();
            var actualMessage = Assert.Throws<ArgumentNullException>(() => new TrollPhotoService(null, repositoryMock.Object));

            StringAssert.IsMatch("unitOfWork", actualMessage.ParamName);
        }

        [Test]
        public void CreateCorrectInstanceOfTrollPhotoService_WhenPassedArgumentsAreValid()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IWhoScoredRepository<TrollPhoto>>();

            ITrollPhotoService trollPhotoService = new TrollPhotoService(unitOfWorkMock.Object, repositoryMock.Object);

            Assert.IsInstanceOf<TrollPhotoService>(trollPhotoService);
        }
    }
}