﻿using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WhoScored.Models.Models;

namespace WhoScored.Tests.WhoScored.Models.CommentTests
{
    [TestFixture]
    public class ContextTests
    {
        [Test]
        public void Context_ShouldHave_RequiredAttribute()
        {
            Comment comment = new Comment();
            string property = "Context";

            bool hasAttribute = comment.GetType()
                .GetProperty(property)
                .GetCustomAttributes(false)
                .Where(p => p.GetType() == typeof(RequiredAttribute))
                .Any();

            Assert.IsTrue(hasAttribute);
        }
    }
}
