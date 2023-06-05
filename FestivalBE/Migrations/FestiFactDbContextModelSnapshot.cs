﻿// <auto-generated />
using System;
using FestivalBE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FestivalBE.Migrations
{
    [DbContext(typeof(FestiFactDbContext))]
    partial class FestiFactDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FestivalBE.Models.Artiest", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Afbeelding")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Beschrijving")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LandVanHerkomst")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artiesten");
                });

            modelBuilder.Entity("FestivalBE.Models.ArtiestFavoriet", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("ArtiestId")
                        .HasColumnType("int");

                    b.Property<int?>("BezoekerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtiestId");

                    b.HasIndex("BezoekerId");

                    b.ToTable("ArtiestFavorieten");
                });

            modelBuilder.Entity("FestivalBE.Models.Bezoeker", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Geboortedatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bezoekers");
                });

            modelBuilder.Entity("FestivalBE.Models.Festival", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("BannerAfbeelding")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Beschrijving")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EindDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LeeftijdscategorieTot")
                        .HasColumnType("int");

                    b.Property<int?>("LeeftijdscategorieVan")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrganisatorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrganisatorId");

                    b.ToTable("Festivals");
                });

            modelBuilder.Entity("FestivalBE.Models.Locatie", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locaties");
                });

            modelBuilder.Entity("FestivalBE.Models.Organisator", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organisators");
                });

            modelBuilder.Entity("FestivalBE.Models.Rating", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("BezoekerId")
                        .HasColumnType("int");

                    b.Property<string>("Opmerking")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Score")
                        .HasColumnType("int");

                    b.Property<int?>("VoorstellingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BezoekerId");

                    b.HasIndex("VoorstellingId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("FestivalBE.Models.Ticket", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("BezoekerId")
                        .HasColumnType("int");

                    b.Property<int?>("VoorstellingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BezoekerId");

                    b.HasIndex("VoorstellingId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("FestivalBE.Models.Voorstelling", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Afbeelding")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ArtiestId")
                        .HasColumnType("int");

                    b.Property<string>("Beschrijving")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EindTijd")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FestivalId")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartTijd")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ZaalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtiestId");

                    b.HasIndex("FestivalId");

                    b.HasIndex("ZaalId");

                    b.ToTable("Voorstellingen");
                });

            modelBuilder.Entity("FestivalBE.Models.VoorstellingFavoriet", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("BezoekerId")
                        .HasColumnType("int");

                    b.Property<int?>("VoorstellingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BezoekerId");

                    b.HasIndex("VoorstellingId");

                    b.ToTable("VoorstellingFavorieten");
                });

            modelBuilder.Entity("FestivalBE.Models.Zaal", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("Capaciteit")
                        .HasColumnType("int");

                    b.Property<int?>("LocatieId")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocatieId");

                    b.ToTable("Zalen");
                });

            modelBuilder.Entity("FestivalLocatie", b =>
                {
                    b.Property<int>("FestivalsId")
                        .HasColumnType("int");

                    b.Property<int>("LocatiesId")
                        .HasColumnType("int");

                    b.HasKey("FestivalsId", "LocatiesId");

                    b.HasIndex("LocatiesId");

                    b.ToTable("FestivalLocatie");
                });

            modelBuilder.Entity("FestivalBE.Models.ArtiestFavoriet", b =>
                {
                    b.HasOne("FestivalBE.Models.Artiest", "Artiest")
                        .WithMany()
                        .HasForeignKey("ArtiestId");

                    b.HasOne("FestivalBE.Models.Bezoeker", "Bezoeker")
                        .WithMany("ArtiestFavorieten")
                        .HasForeignKey("BezoekerId");

                    b.Navigation("Artiest");

                    b.Navigation("Bezoeker");
                });

            modelBuilder.Entity("FestivalBE.Models.Festival", b =>
                {
                    b.HasOne("FestivalBE.Models.Organisator", "Organisator")
                        .WithMany("Festivals")
                        .HasForeignKey("OrganisatorId");

                    b.Navigation("Organisator");
                });

            modelBuilder.Entity("FestivalBE.Models.Rating", b =>
                {
                    b.HasOne("FestivalBE.Models.Bezoeker", "Bezoeker")
                        .WithMany("Ratings")
                        .HasForeignKey("BezoekerId");

                    b.HasOne("FestivalBE.Models.Voorstelling", "Voorstelling")
                        .WithMany("Ratings")
                        .HasForeignKey("VoorstellingId");

                    b.Navigation("Bezoeker");

                    b.Navigation("Voorstelling");
                });

            modelBuilder.Entity("FestivalBE.Models.Ticket", b =>
                {
                    b.HasOne("FestivalBE.Models.Bezoeker", "Bezoeker")
                        .WithMany("Tickets")
                        .HasForeignKey("BezoekerId");

                    b.HasOne("FestivalBE.Models.Voorstelling", "Voorstelling")
                        .WithMany()
                        .HasForeignKey("VoorstellingId");

                    b.Navigation("Bezoeker");

                    b.Navigation("Voorstelling");
                });

            modelBuilder.Entity("FestivalBE.Models.Voorstelling", b =>
                {
                    b.HasOne("FestivalBE.Models.Artiest", "Artiest")
                        .WithMany("Voorstellingen")
                        .HasForeignKey("ArtiestId");

                    b.HasOne("FestivalBE.Models.Festival", "Festival")
                        .WithMany("Voorstellingen")
                        .HasForeignKey("FestivalId");

                    b.HasOne("FestivalBE.Models.Zaal", "Zaal")
                        .WithMany("Voorstellingen")
                        .HasForeignKey("ZaalId");

                    b.Navigation("Artiest");

                    b.Navigation("Festival");

                    b.Navigation("Zaal");
                });

            modelBuilder.Entity("FestivalBE.Models.VoorstellingFavoriet", b =>
                {
                    b.HasOne("FestivalBE.Models.Bezoeker", "Bezoeker")
                        .WithMany("VoorstellingFavorieten")
                        .HasForeignKey("BezoekerId");

                    b.HasOne("FestivalBE.Models.Voorstelling", "Voorstelling")
                        .WithMany()
                        .HasForeignKey("VoorstellingId");

                    b.Navigation("Bezoeker");

                    b.Navigation("Voorstelling");
                });

            modelBuilder.Entity("FestivalBE.Models.Zaal", b =>
                {
                    b.HasOne("FestivalBE.Models.Locatie", "Locatie")
                        .WithMany("Zalen")
                        .HasForeignKey("LocatieId");

                    b.Navigation("Locatie");
                });

            modelBuilder.Entity("FestivalLocatie", b =>
                {
                    b.HasOne("FestivalBE.Models.Festival", null)
                        .WithMany()
                        .HasForeignKey("FestivalsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FestivalBE.Models.Locatie", null)
                        .WithMany()
                        .HasForeignKey("LocatiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FestivalBE.Models.Artiest", b =>
                {
                    b.Navigation("Voorstellingen");
                });

            modelBuilder.Entity("FestivalBE.Models.Bezoeker", b =>
                {
                    b.Navigation("ArtiestFavorieten");

                    b.Navigation("Ratings");

                    b.Navigation("Tickets");

                    b.Navigation("VoorstellingFavorieten");
                });

            modelBuilder.Entity("FestivalBE.Models.Festival", b =>
                {
                    b.Navigation("Voorstellingen");
                });

            modelBuilder.Entity("FestivalBE.Models.Locatie", b =>
                {
                    b.Navigation("Zalen");
                });

            modelBuilder.Entity("FestivalBE.Models.Organisator", b =>
                {
                    b.Navigation("Festivals");
                });

            modelBuilder.Entity("FestivalBE.Models.Voorstelling", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("FestivalBE.Models.Zaal", b =>
                {
                    b.Navigation("Voorstellingen");
                });
#pragma warning restore 612, 618
        }
    }
}
