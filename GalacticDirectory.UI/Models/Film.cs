using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalacticDirectory.UI.Models
{
    public class Film
    {
       
        public int ID { get; set; }
      //  public int PeopleID { get; set; }
        public string Name { get; set; }
        public Film( int id,string name)//int peopleid,
        {
           // PeopleID = peopleid;
            ID = id;
            Name = name;
        }
    }
}