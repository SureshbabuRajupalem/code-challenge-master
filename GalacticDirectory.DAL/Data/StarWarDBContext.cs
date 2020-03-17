using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalacticDirectory.DAL.EFModels;

namespace GalacticDirectory.DAL.Data
{
    public class StarWarDBContext:DbContext
    {

        public DbSet<PeopleModel> People { get; set; }
        public DbSet<FilmModel> Films { get; set; }
        public DbSet<SpeciesModel> Species { get; set; }
        public DbSet<VehicleModel> Vehicles { get; set; }
        public StarWarDBContext(DbContextOptions<StarWarDBContext> options):base(options)
        {
            Database.Migrate();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("StarWarCon");
        //    //base.OnConfiguring(optionsBuilder);
        //}
    }
}