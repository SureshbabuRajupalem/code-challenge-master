﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalacticDirectory.UI.Models
{
    public class PlanetModelRoot
    {

        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<PlanetModel> PlanetModel { get; set; }
    }
}
