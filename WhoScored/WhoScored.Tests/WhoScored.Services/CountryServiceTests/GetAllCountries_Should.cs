﻿using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.Tests.WhoScored.Services.CountryServiceTests
{
    [TestFixture]
    public class GetAllCountries_Should
    {
        [Test]
        public void GetAllCountries()
        {
            var mockedCountryRepository = new Mock<IWhoScoredRepository<Country>>();
            ICountryService countryService = new CountryService(mockedCountryRepository.Object);

            IEnumerable<Country> countries = new List<Country>()
            {
                new Country() {Id = 1, Name = "Spain"},
                new Country() {Id = 1, Name = "Buglaria"}
            };

            mockedCountryRepository.Setup(x => x.GetAll()).Returns(countries);
            var actualCountries = countryService.GetAllCountries();

            CollectionAssert.AreEquivalent(countries, actualCountries);
        }

        [Test]
        public void CallRepositoryMethodOnce()
        {
            var mockedCountryRepository = new Mock<IWhoScoredRepository<Country>>();
            ICountryService countryService = new CountryService(mockedCountryRepository.Object);

            countryService.GetAllCountries();
            
            mockedCountryRepository.Verify(x=>x.GetAll(), Times.Once);
        }
    }
}