using System.Collections.Generic;
using WhoScored.Models.Models;

namespace WhoScored.MVP.Models
{
    public class TrollPhotosViewModel
    {
        public IEnumerable<TrollPhoto> TrollPhotosCollection { get; set; }
    }
}