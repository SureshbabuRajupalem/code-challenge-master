using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalacticDirectory.UI.Models
{
    public class PeopleModelRoot
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public PeopleModel[] results { get; set; }
    }
}
