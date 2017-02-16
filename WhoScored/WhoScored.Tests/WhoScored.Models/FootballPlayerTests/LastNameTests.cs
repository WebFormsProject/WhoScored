using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WhoScored.Models.Models;

namespace WhoScored.Tests.WhoScored.Models.FootballPlayerTests
{
    [TestFixture]
    public class LastNameTests
    {
        [Test]
        public void LastName_ShouldHave_RequiredAttribute()
        {
            FootballPlayer player = new FootballPlayer();
            string property = "LastName";

            bool hasAttribute = player.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(RequiredAttribute))
                .Any();

            Assert.IsTrue(hasAttribute);
        }
    }
}
