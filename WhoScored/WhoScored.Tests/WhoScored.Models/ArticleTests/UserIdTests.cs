using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WhoScored.Models.Models;

namespace WhoScored.Tests.WhoScored.Models.ArticleTests
{
    [TestFixture]
    public class UserIdTests
    {
        [Test]
        public void UserId_ShouldHave_RequiredAttribute()
        {
            Article article = new Article();
            string property = "UserId";

            bool hasAttribute = article.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(RequiredAttribute))
                .Any();

            Assert.IsTrue(hasAttribute);
        }
    }
}
