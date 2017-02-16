using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WhoScored.Models.Models;

namespace WhoScored.Tests.WhoScored.Models.CategoryTests
{
    [TestFixture]
    public class NameTests
    {
        [Test]
        public void Title_ShouldHave_RequiredAttribute()
        {
            Category category = new Category();
            string property = "Name";

            bool hasAttribute = category.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(RequiredAttribute))
                .Any();

            Assert.IsTrue(hasAttribute);
        }
    }
}
