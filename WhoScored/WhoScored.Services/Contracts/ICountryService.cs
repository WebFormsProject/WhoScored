using System.Collections.Generic;
using WhoScored.Models.Models;

namespace WhoScored.Services.Contracts
{
    public interface ICountryService
    {
        IEnumerable<Country> GetAllCountries();
    }
}
