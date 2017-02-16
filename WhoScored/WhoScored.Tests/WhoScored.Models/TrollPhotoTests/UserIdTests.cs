using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WhoScored.Models.Models;

namespace WhoScored.Tests.WhoScored.Models.TrollPhotoTests
{
    [TestFixture]
    public class UserIdTests
    {
        [Test]
        public void UserId_ShouldHave_RequiredAttribute()
        {
            TrollPhoto photo = new TrollPhoto();
            string property = "UserId";

            bool hasAttribute = photo.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(RequiredAttribute))
                .Any();

            Assert.IsTrue(hasAttribute);
        }
    }
}
