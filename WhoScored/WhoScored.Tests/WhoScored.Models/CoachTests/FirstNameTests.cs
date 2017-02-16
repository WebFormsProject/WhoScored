using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WhoScored.Models.Models;

namespace WhoScored.Tests.WhoScored.Models.CoachTests
{
    [TestFixture]
    public class FirstNameTests
    {
        [Test]
        public void FirstName_ShouldHave_RequiredAttribute()
        {
            Coach coach = new Coach();
            string property = "FirstName";

            bool hasAttibute = coach.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(RequiredAttribute))
                .Any();

            Assert.IsTrue(hasAttibute);
        }
    }
}
