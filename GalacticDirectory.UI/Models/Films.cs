using iRely.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalacticDirectory.UI.Models
{
    public class Films:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int PeopleID { get; set; }
        public string Name { get; set; }
        public Films(int peopleid, int id,string name)
        {
            PeopleID = peopleid;
            ID = id;
            Name = name;
        }
    }
}