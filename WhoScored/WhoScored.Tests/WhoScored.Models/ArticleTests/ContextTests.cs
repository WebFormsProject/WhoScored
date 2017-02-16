using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WhoScored.Models.Models;

namespace WhoScored.Tests.WhoScored.Models.ArticleTests
{
    [TestFixture]
    public class ContextTests
    {
        [Test]
        public void Context_ShouldHave_RequiredAttribute()
        {
            Article article = new Article();
            string property = "Context";

            bool hasAttribute = article.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(RequiredAttribute))
                .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Context_ShouldHave_MinLengthAttribute()
        {
            Article article = new Article();
            string property = "Context";

            bool hasAttribute = article.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(MinLengthAttribute))
                .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Context_ShouldHave_MinValueConstraintWithCorrectValue()
        {
            Article article = new Article();
            string property = "Context";

            MinLengthAttribute attribute = article.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(MinLengthAttribute))
                .Select(x => (MinLengthAttribute)x)
                .Single();

            Assert.AreEqual(ValidationConstants.ArticleContextMinLength, attribute.Length);
        }
    }
}
