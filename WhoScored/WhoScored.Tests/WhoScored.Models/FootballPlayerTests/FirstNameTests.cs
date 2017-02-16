using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WhoScored.Models.Models;

namespace WhoScored.Tests.WhoScored.Models.FootballPlayerTests
{
    [TestFixture]
    public class FirstNameTests
    {
        [Test]
        public void FirstName_ShouldHave_RequiredAttribute()
        {
            FootballPlayer player = new FootballPlayer();
            string property = "FirstName";

            bool hasAttribute = player.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(RequiredAttribute))
                .Any();

            Assert.IsTrue(hasAttribute);
        }
    }
}
