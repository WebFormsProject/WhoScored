using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WhoScored.Models.Models;

namespace WhoScored.Tests.WhoScored.Models.CoachTests
{
    [TestFixture]
    public class LastNameTests
    {
        [Test]
        public void LastName_ShouldHave_RequiredAttribute()
        {
            Coach coach = new Coach();
            string property = "LastName";

            bool hasAttibute = coach.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(RequiredAttribute))
                .Any();

            Assert.IsTrue(hasAttibute);
        }
    }
}
