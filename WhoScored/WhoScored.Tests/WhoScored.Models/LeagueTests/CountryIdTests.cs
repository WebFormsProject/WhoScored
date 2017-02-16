using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WhoScored.Models.Models;

namespace WhoScored.Tests.WhoScored.Models.LeagueTests
{
    [TestFixture]
    public class CountryIdTests
    {
        [Test]
        public void CountryId_ShouldHave_RequiredAttribute()
        {
            League league = new League();
            string property = "CountryId";

            bool hasAttribute = league.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(RequiredAttribute))
                .Any();

            Assert.IsTrue(hasAttribute);
        }
    }
}
