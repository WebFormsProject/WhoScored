using System.Collections.Generic;
using Bytes2you.Validation;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.Services.Contracts;

namespace WhoScored.Services
{
    public class CountryService : ICountryService
    {

        private readonly IWhoScoredRepository<Country> countryRepository;

        public CountryService(IWhoScoredRepository<Country> countryRepository)
        {
            Guard.WhenArgument(countryRepository, "countryRepository").IsNull().Throw();
            this.countryRepository = countryRepository;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return this.countryRepository.GetAll();
        }
    }
}
