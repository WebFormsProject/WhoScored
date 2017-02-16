using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WhoScored.Models;

namespace WhoScored.Tests.WhoScored.Models.CountryTests
{
    [TestFixture]
    public class NameTests
    {
        [Test]
        public void Name_ShouldHave_RequiredAttribute()
        {
            Country country = new Country();
            string property = "Name";

            bool hasAttribute = country.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(RequiredAttribute))
                .Any();

            Assert.IsTrue(hasAttribute);
        }
    }
}
