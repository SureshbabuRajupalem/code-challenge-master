using iRely.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalacticDirectory.UI.Models
{
    public class PeopleModel:BaseEntity
    {

        public int People_ID { get; set; }
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public string Hair_color { get; set; }
        public string Skin_color { get; set; }
        public string Eye_color { get; set; }
        public string Birth_year { get; set; }
        public string Gender { get; set; }
        public string Homeworld { get; set; }
        public String[] Films { get; set; }
        public String[] Species { get; set; }
        public String[] Vehicles { get; set; }
        public String[] Starships { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; }
    }
}
