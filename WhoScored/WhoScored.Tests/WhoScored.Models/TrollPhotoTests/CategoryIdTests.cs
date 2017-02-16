using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WhoScored.Models.Models;

namespace WhoScored.Tests.WhoScored.Models.TrollPhotoTests
{
    [TestFixture]
    public class CategoryIdTests
    {
        [Test]
        public void CategoryId_ShouldHave_RequiredAttribute()
        {
            TrollPhoto photo = new TrollPhoto();
            string property = "CategoryId";

            bool hasAttribute = photo.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(RequiredAttribute))
                .Any();

            Assert.IsTrue(hasAttribute);
        }
    }
}
