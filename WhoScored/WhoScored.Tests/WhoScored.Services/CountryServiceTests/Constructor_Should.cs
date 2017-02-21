using System;
using Moq;
using NUnit.Framework;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.CountryServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedArgumentIsNull()
        {
            var actualMessage = Assert.Throws<ArgumentNullException>(() => new CountryService(null));

            StringAssert.IsMatch("countryRepository", actualMessage.ParamName);
        }

        [Test]
        public void CreateCorrectInstanceOfCountryService_WhenPassedArgumentIsValid()
        {
            var mockedCountryRepository = new Mock<IWhoScoredRepository<Country>>();
            ICountryService countryService = new CountryService(mockedCountryRepository.Object);

            Assert.IsInstanceOf(typeof(CountryService), countryService);
        }
    }
}
