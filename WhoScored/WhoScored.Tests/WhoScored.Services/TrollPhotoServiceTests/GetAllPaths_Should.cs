using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.TrollPhotoServiceTests
{
    [TestFixture]
    public class GetAllPaths_Should
    {
        [Test]
        public void GetAllTrollPhotosPaths()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<TrollPhoto>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            ITrollPhotoService trollPhotoService = new TrollPhotoService(unitOfWorkMock.Object, repositoryMock.Object);

            IEnumerable<TrollPhoto> trollPhotos = new List<TrollPhoto>();
            repositoryMock.Setup(x => x.GetAll()).Returns(trollPhotos);

            IEnumerable<string> actualTrollPhotosPaths = trollPhotoService.GetAllPaths();
            IEnumerable<string> trollPhotosPaths = trollPhotos.Select(x => x.PhotoPath);

            CollectionAssert.AreEquivalent(trollPhotosPaths, actualTrollPhotosPaths);
        }

        [Test]
        public void CallRepositoryMethodOnce()
        {
            var repositoryMock = new Mock<IWhoScoredRepository<TrollPhoto>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            ITrollPhotoService trollPhotoService = new TrollPhotoService(unitOfWorkMock.Object, repositoryMock.Object);

            trollPhotoService.GetAllPaths();

            repositoryMock.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
