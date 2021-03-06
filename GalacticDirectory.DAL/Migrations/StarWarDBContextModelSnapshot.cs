﻿// <auto-generated />
using System;
using GalacticDirectory.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GalacticDirectory.DAL.Migrations
{
    [DbContext(typeof(StarWarDBContext))]
    partial class StarWarDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GalacticDirectory.DAL.EFModels.FilmModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PeopleID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("GalacticDirectory.DAL.EFModels.PeopleModel", b =>
                {
                    b.Property<int>("People_ID")
                        // .ValueGeneratedOnAdd()
                        .HasColumnType("int");
                       // .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Birth_year")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Edited")
                        .HasColumnType("datetime2");

                    b.Property<string>("Eye_color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hair_color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Height")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Homeworld")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Skin_color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("People_ID");

                    b.ToTable("People");
                });

            modelBuilder.Entity("GalacticDirectory.DAL.EFModels.SpeciesModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PeopleID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("GalacticDirectory.DAL.EFModels.VehicleModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PeopleID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
