using Moq;
using NUnit.Framework;
using System;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.TrollPhotoServiceTests
{
    [TestFixture]
    public class UploadTrollPhoto_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedUserIdIsNull()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IWhoScoredRepository<TrollPhoto>>();
            ITrollPhotoService trollPhotoService = new TrollPhotoService(unitOfWorkMock.Object, repositoryMock.Object);

            string filePath = "path";
            var actualMessage = Assert.Throws<ArgumentNullException>(() => trollPhotoService.UploadTrollPhoto(null, filePath));

            StringAssert.IsMatch("userId", actualMessage.ParamName);
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedFilePathIsNull()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IWhoScoredRepository<TrollPhoto>>();
            ITrollPhotoService trollPhotoService = new TrollPhotoService(unitOfWorkMock.Object, repositoryMock.Object);

            string userId = "id";
            var actualMessage = Assert.Throws<ArgumentNullException>(() => trollPhotoService.UploadTrollPhoto(userId, null));

            StringAssert.IsMatch("filePath", actualMessage.ParamName);
        }

        [Test]
        public void CallRepositoryMethodOnce_WhenPassedParametersAreValid()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<TrollPhoto>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            ITrollPhotoService trollPhotoService = new TrollPhotoService(unitOfWorkMock.Object, repositoryMock.Object);

            string userId = "id";
            string filePath = "path";
            trollPhotoService.UploadTrollPhoto(userId, filePath);

            repositoryMock.Verify(x => x.Add(It.IsAny<TrollPhoto>()), Times.Once);
        }

        [Test]
        public void CallUnitOfWorkCommitMethodOncee_WhenPassedParametersAreValid()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<TrollPhoto>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            ITrollPhotoService trollPhotoService = new TrollPhotoService(unitOfWorkMock.Object, repositoryMock.Object);

            string userId = "id";
            string filePath = "path";
            trollPhotoService.UploadTrollPhoto(userId, filePath);

            unitOfWorkMock.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void CallUnitOfWorkDisposeMethodOnce()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<TrollPhoto>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            ITrollPhotoService trollPhotoService = new TrollPhotoService(unitOfWorkMock.Object, repositoryMock.Object);

            unitOfWorkMock.Setup(x => x.Dispose()).Verifiable();

            string userId = "id";
            string filePath = "path";
            trollPhotoService.UploadTrollPhoto(userId, filePath);

            unitOfWorkMock.Verify(x => x.Dispose(), Times.Once);
        }
    }
}
