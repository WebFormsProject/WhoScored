using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WhoScored.Models.Models;

namespace WhoScored.Tests.WhoScored.Models.ArticleTests
{
    [TestFixture]
    public class TitleTests
    {
        [Test]
        public void Title_ShouldHave_RequiredAttribute()
        {
            Article article = new Article();
            string property = "Title";

            bool hasAttribute = article.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(RequiredAttribute))
                .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Title_ShouldHave_MinLengthAttribute()
        {
            Article article = new Article();
            string property = "Title";

            bool hasAttribute = article.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(MinLengthAttribute))
                .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Title_ShouldHave_MaxLengthAttribute()
        {
            Article article = new Article();
            string property = "Title";

            bool hasAttribute = article.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(MaxLengthAttribute))
                .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Title_ShouldHave_MinValueConstraintWithCorrectValue()
        {
            Article article = new Article();
            string property = "Title";

            MinLengthAttribute attribute = article.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(MinLengthAttribute))
                .Select(x => (MinLengthAttribute)x)
                .Single();

            Assert.AreEqual(ValidationConstants.ArticleTitleMinLength, attribute.Length);
        }

        [Test]
        public void Title_ShouldHave_MaxValueConstraintWithCorrectValue()
        {
            Article article = new Article();
            string property = "Title";

            MaxLengthAttribute attribute = article.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(MaxLengthAttribute))
                .Select(x => (MaxLengthAttribute)x)
                .Single();

            Assert.AreEqual(ValidationConstants.ArticleTitleMaxLength, attribute.Length);
        }
    }
}
