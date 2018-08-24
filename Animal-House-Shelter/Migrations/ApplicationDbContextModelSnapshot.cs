﻿// <auto-generated />
using Animal_House_Shelter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnimalHouseShelter.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Animal_House_Shelter.Models.Cat", b =>
                {
                    b.Property<int>("CatID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("Breed");

                    b.Property<string>("Description");

                    b.Property<string>("Gender");

                    b.Property<string>("ImgUrl");

                    b.Property<string>("Name");

                    b.Property<int>("Weight");

                    b.HasKey("CatID");

                    b.ToTable("Cats");
                });

            modelBuilder.Entity("Animal_House_Shelter.Models.Dog", b =>
                {
                    b.Property<int>("DogID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("Breed");

                    b.Property<string>("Description");

                    b.Property<string>("Gender");

                    b.Property<string>("ImgUrl");

                    b.Property<string>("Name");

                    b.Property<int>("Weight");

                    b.HasKey("DogID");

                    b.ToTable("Dogs");
                });
#pragma warning restore 612, 618
        }
    }
}
