﻿namespace GalacticDirectory.UI.Models
{
    public class Species
    {
        public int ID { get; set; }
        public int PeopleID { get; set; }
        public string Name { get; set; }
        public Species(int peopleid, int id, string name)
        {
            PeopleID = peopleid;
            ID = id;
            Name = name;
        }
    }
}