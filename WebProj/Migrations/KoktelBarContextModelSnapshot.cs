// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebProj.Models;

namespace WebProj.Migrations
{
    [DbContext(typeof(KoktelBarContext))]
    partial class KoktelBarContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("WebProj.Models.KoktelBar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Adresa");

                    b.Property<int>("Kapacitet")
                        .HasColumnType("int")
                        .HasColumnName("Kapacitet");

                    b.Property<int>("MaxLjudi")
                        .HasColumnType("int")
                        .HasColumnName("MaxLjudi");

                    b.Property<int>("MaxLokala")
                        .HasColumnType("int")
                        .HasColumnName("MaxLokala");

                    b.Property<string>("Naziv")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Naziv");

                    b.HasKey("ID");

                    b.ToTable("KoktelBar");
                });

            modelBuilder.Entity("WebProj.Models.Porudzbina", b =>
                {
                    b.Property<int>("IDPorudzbine")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDPorudzbine")
                        .UseIdentityColumn();

                    b.Property<string>("Deserti")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Deserti");

                    b.Property<int?>("KoktelBarID")
                        .HasColumnType("int");

                    b.Property<string>("Pice")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Pice");

                    b.HasKey("IDPorudzbine");

                    b.HasIndex("KoktelBarID");

                    b.ToTable("Porudzbina");
                });

            modelBuilder.Entity("WebProj.Models.Sto", b =>
                {
                    b.Property<int>("IDStola")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDStola")
                        .UseIdentityColumn();

                    b.Property<int>("BrojStola")
                        .HasColumnType("int")
                        .HasColumnName("BrojStola");

                    b.Property<string>("Ime")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Ime");

                    b.Property<int>("KapacitetStola")
                        .HasColumnType("int")
                        .HasColumnName("KapacitetStola");

                    b.Property<int?>("KoktelBarID")
                        .HasColumnType("int");

                    b.Property<int>("MaxKapacitet")
                        .HasColumnType("int")
                        .HasColumnName("MaxKapacitet");

                    b.Property<string>("Prezime")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Prezime");

                    b.Property<string>("Stanje")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Stanje");

                    b.HasKey("IDStola");

                    b.HasIndex("KoktelBarID");

                    b.ToTable("Sto");
                });

            modelBuilder.Entity("WebProj.Models.Porudzbina", b =>
                {
                    b.HasOne("WebProj.Models.KoktelBar", "KoktelBar")
                        .WithMany("Porudzbine")
                        .HasForeignKey("KoktelBarID");

                    b.Navigation("KoktelBar");
                });

            modelBuilder.Entity("WebProj.Models.Sto", b =>
                {
                    b.HasOne("WebProj.Models.KoktelBar", "KoktelBar")
                        .WithMany("Stolovi")
                        .HasForeignKey("KoktelBarID");

                    b.Navigation("KoktelBar");
                });

            modelBuilder.Entity("WebProj.Models.KoktelBar", b =>
                {
                    b.Navigation("Porudzbine");

                    b.Navigation("Stolovi");
                });
#pragma warning restore 612, 618
        }
    }
}
