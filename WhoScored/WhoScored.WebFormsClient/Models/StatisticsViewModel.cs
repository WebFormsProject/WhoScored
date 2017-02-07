using System.Collections.Generic;
using WhoScored.Models.Models;

namespace WhoScored.WebFormsClient.Models
{
    public class StatisticsViewModel
    {
        public IEnumerable<Team> Teams
        {
            get;
            set;
        }
    }
}