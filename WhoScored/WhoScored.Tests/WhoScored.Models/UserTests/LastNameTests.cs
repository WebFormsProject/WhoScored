﻿using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WhoScored.Models.Models;

namespace WhoScored.Tests.WhoScored.Models.UserTests
{
    [TestFixture]
    public class LastNameTests
    {
        [Test]
        public void LastName_ShouldHave_RequiredAttribute()
        {
            User user = new User();
            string property = "LastName";

            bool hasAttribute = user.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(RequiredAttribute))
                .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void LastName_ShouldHave_MaxLengthAttribute()
        {
            User user = new User();
            string property = "LastName";

            bool hasAttribute = user.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(MaxLengthAttribute))
                .Any();

            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void LastName_ShouldHave_MaxValueConstraintWithCorrectValue()
        {
            User user = new User();
            string property = "LastName";

            MaxLengthAttribute attribute = user.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(MaxLengthAttribute))
                .Select(x => (MaxLengthAttribute)x)
                .Single();

            Assert.AreEqual(ValidationConstants.UserLastNameMaxLength, attribute.Length);
        }
    }
}
