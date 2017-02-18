﻿using System.Collections.Generic;
using WhoScored.Models.Models;

namespace WhoScored.WebFormsClient.Models
{
    public class ScoresModelView
    {
        public IEnumerable<League> Leagues { get; set; }

        public IEnumerable<Game> GamesByLeague { get; set; }
    }
}