using System.Collections.Generic;
using WhoScored.Models.Models;

namespace WhoScored.WebFormsClient.Models
{
    public class LeaguesViewModel
    {
        public IEnumerable<League> Leagues { get; set; } 
    }
}