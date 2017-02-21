using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Views;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.MVP.TrollPhotosPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenITrollPhotoServiceIsNull()
        {
            var viewMock = new Mock<ITrollPhotosView>();

            var exception = Assert.Throws<ArgumentNullException>(() => new TrollPhotosPresenter(viewMock.Object, null));

            StringAssert.IsMatch("trollPhotoService", exception.ParamName);
        }

        [Test]
        public void CreateInstance_WhenParametersAreValid()
        {
            var viewMock = new Mock<ITrollPhotosView>();
            var trollPhotoServiceMock = new Mock<ITrollPhotoService>();

            TrollPhotosPresenter presenter = new TrollPhotosPresenter(viewMock.Object, trollPhotoServiceMock.Object);

            Assert.IsInstanceOf<TrollPhotosPresenter>(presenter);
        }
    }
}
