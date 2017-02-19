using System.Collections.Generic;
using WhoScored.Models.Models;

namespace WhoScored.MVP.Models
{
    public class StatisticsViewModel
    {
        public IEnumerable<Team> Teams { get; set; }
    }
}