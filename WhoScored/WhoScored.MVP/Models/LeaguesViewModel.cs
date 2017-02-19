using System.Collections.Generic;
using WhoScored.Models.Models;

namespace WhoScored.MVP.Models
{
    public class LeaguesViewModel
    {
        public IEnumerable<League> Leagues { get; set; } 
    }
}