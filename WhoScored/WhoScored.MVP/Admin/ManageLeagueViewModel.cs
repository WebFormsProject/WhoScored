using System.Collections.Generic;
using WhoScored.Models.Models;

namespace WhoScored.MVP.Admin
{
    public class ManageLeagueViewModel
    {
        public IEnumerable<League> Leagues { get; set; } 

        public IEnumerable<Country> Countries { get; set; } 
    }
}
