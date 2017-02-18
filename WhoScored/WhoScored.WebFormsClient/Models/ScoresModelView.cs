using System.Collections.Generic;
using System.Linq;
using WhoScored.Models.Models;

namespace WhoScored.WebFormsClient.Models
{
    public class ScoresModelView
    {
        public IEnumerable<IGrouping<League,Game>> Games { get; set; }
    }
}