using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using WhoScored.MVP.Models;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.MVP.TrollPhotosPresenterTests
{
    [TestFixture]
    public class View_GetTrollPhotosPaths_Should
    {
        [Test]
        public void AddTrollPhotosPathsOnModelView_WhenGetTrollPhotosPathsIsRaised()
        {
            var viewMock = new Mock<ITrollPhotosView>();
            var trollPhotoServiceMock = new Mock<ITrollPhotoService>();
            
            IEnumerable<string> paths = new List<string>();
            trollPhotoServiceMock.Setup(x => x.GetAllPaths()).Returns(paths);
            
            TrollPhotosViewModel model = new TrollPhotosViewModel();
            viewMock.Setup(x => x.Model).Returns(model);

            TrollPhotosPresenter presenter = new TrollPhotosPresenter(viewMock.Object, trollPhotoServiceMock.Object);
            
            viewMock.Raise(x=>x.GetTrollPhotosPaths += null, EventArgs.Empty);

            CollectionAssert.AreEquivalent(paths, viewMock.Object.Model.TrollPhotosPaths);
        }
    }
}
