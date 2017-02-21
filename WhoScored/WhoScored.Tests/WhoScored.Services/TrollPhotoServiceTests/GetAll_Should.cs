using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.TrollPhotosServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void GetAllTrollPhotos()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<TrollPhoto>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            ITrollPhotoService trollPhotoService = new TrollPhotoService(unitOfWorkMock.Object, repositoryMock.Object);

            IEnumerable<TrollPhoto> trollPhotos = new List<TrollPhoto>();
            repositoryMock.Setup(x => x.GetAll()).Returns(trollPhotos);

            IEnumerable<TrollPhoto> actualTrollPhotos = trollPhotoService.GetAll();

            CollectionAssert.AreEquivalent(trollPhotos, actualTrollPhotos);
        }

        [Test]
        public void CallRepositoryMethodOnce()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<TrollPhoto>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            ITrollPhotoService trollPhotoService = new TrollPhotoService(unitOfWorkMock.Object, repositoryMock.Object);

            trollPhotoService.GetAll();

            repositoryMock.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
