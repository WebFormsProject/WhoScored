using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WhoScored.Models.Models;

namespace WhoScored.Tests.WhoScored.Models.TitleTests
{
    [TestFixture]
    public class TitleNameTests
    {
        [Test]
        public void TitleName_ShouldHave_RequiredAttribute()
        {
            Title title = new Title();
            string property = "TitleName";

            bool hasAttribute = title.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(RequiredAttribute))
                .Any();

            Assert.IsTrue(hasAttribute);
        }
    }
}
