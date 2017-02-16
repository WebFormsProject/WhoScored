using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WhoScored.Models.Models;

namespace WhoScored.Tests.WhoScored.Models.LeagueTests
{
    [TestFixture]
    public class NameTests
    {
        [Test]
        public void Name_ShouldHave_RequiredAttribute()
        {
            League league = new League();
            string property = "Name";

            bool hasAttribute = league.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(RequiredAttribute))
                .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Name_ShouldHave_MinLengthAttribute()
        {
            League league = new League();
            string property = "Name";

            bool hasAttribute = league.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(MinLengthAttribute))
                .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Name_ShouldHave_MinValueConstraintWithCorrectValue()
        {
            League league = new League();
            string property = "Name";

            MinLengthAttribute attribute = league.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(MinLengthAttribute))
                .Select(x => (MinLengthAttribute)x)
                .Single();

            Assert.AreEqual(ValidationConstants.LeagueNameMinLength, attribute.Length);
        }
    }
}
