using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalacticDirectory.UI.Models
{
    public class Film
    {
       
        public int ID { get; set; }
        public int PeopleID { get; set; }
        public string Name { get; set; }
        public Film(int peopleid, int id,string name)
        {
            PeopleID = peopleid;
            ID = id;
            Name = name;
        }
    }
}