﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace Aplikacija_swe.Migrations
{
    [DbContext(typeof(SajtContext))]
    [Migration("20220623145825_Autorizacija")]
    partial class Autorizacija
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KorisnikPlan", b =>
                {
                    b.Property<int>("KorisniciPlanoviID")
                        .HasColumnType("int");

                    b.Property<int>("PlanoviKorisniciID")
                        .HasColumnType("int");

                    b.HasKey("KorisniciPlanoviID", "PlanoviKorisniciID");

                    b.HasIndex("PlanoviKorisniciID");

                    b.ToTable("KorisnikPlan");
                });

            modelBuilder.Entity("Models.Administrator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdminSajtID")
                        .HasColumnType("int");

                    b.Property<string>("Autorizacija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("AdminSajtID");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("Models.KomentarIOcena", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Komentar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ocena")
                        .HasColumnType("int");

                    b.Property<int>("OcenaKomentarKorisnikID")
                        .HasColumnType("int");

                    b.Property<int>("OcenaKomentarStrucnjakID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OcenaKomentarKorisnikID");

                    b.HasIndex("OcenaKomentarStrucnjakID");

                    b.ToTable("KomentarIOcena");
                });

            modelBuilder.Entity("Models.Korisnik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Autorizacija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DatumRodjenja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("KolicinaNovca")
                        .HasColumnType("int");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("KorisnikSajtID")
                        .HasColumnType("int");

                    b.Property<string>("Pol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Slika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("KorisnikSajtID");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("Models.Obrok", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Dan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ObrokPlanID")
                        .HasColumnType("int");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SlikaPutanja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipObroka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ObrokPlanID");

                    b.ToTable("Obrok");
                });

            modelBuilder.Entity("Models.Plan", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<int>("IdStrucnogLice")
                        .HasColumnType("int");

                    b.Property<string>("NazivPlana")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oblast")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpisPlana")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlanStrucnjakID")
                        .HasColumnType("int");

                    b.Property<int?>("SajtID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PlanStrucnjakID");

                    b.HasIndex("SajtID");

                    b.ToTable("Plan");
                });

            modelBuilder.Entity("Models.Poruka", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PorukaKorisnikID")
                        .HasColumnType("int");

                    b.Property<string>("PorukaSadrzaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PorukaStrucnjakID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PorukaKorisnikID");

                    b.HasIndex("PorukaStrucnjakID");

                    b.ToTable("Poruke");
                });

            modelBuilder.Entity("Models.Sajt", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsloviIPravilaKoriscenja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Sajt");
                });

            modelBuilder.Entity("Models.StrucnoLice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Autorizacija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrojRacuna")
                        .HasColumnType("int");

                    b.Property<string>("Cet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DatumRodjenja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("KolicinaNovca")
                        .HasColumnType("int");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OblastStruke")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Obrazovanje")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OdobrenjeAdmina")
                        .HasColumnType("bit");

                    b.Property<string>("Pol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Slika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StrucnjakSajtID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("StrucnjakSajtID");

                    b.ToTable("StrucnoLice");
                });

            modelBuilder.Entity("Models.Vezba", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojPonavljanja")
                        .HasColumnType("int");

                    b.Property<string>("Dan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PeriodDanaKadaSeVezbaIzvodi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SlikaPutanja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VezbaPlanID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("VezbaPlanID");

                    b.ToTable("Vezba");
                });

            modelBuilder.Entity("KorisnikPlan", b =>
                {
                    b.HasOne("Models.Plan", null)
                        .WithMany()
                        .HasForeignKey("KorisniciPlanoviID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("PlanoviKorisniciID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Administrator", b =>
                {
                    b.HasOne("Models.Sajt", "AdminSajt")
                        .WithMany("Admini")
                        .HasForeignKey("AdminSajtID");

                    b.Navigation("AdminSajt");
                });

            modelBuilder.Entity("Models.KomentarIOcena", b =>
                {
                    b.HasOne("Models.Korisnik", "OcenaKomentarKorisnik")
                        .WithMany("KorisniciKomentariIOcene")
                        .HasForeignKey("OcenaKomentarKorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.StrucnoLice", "OcenaKomentarStrucnjak")
                        .WithMany("StrucnaLicaKomentariIOcene")
                        .HasForeignKey("OcenaKomentarStrucnjakID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OcenaKomentarKorisnik");

                    b.Navigation("OcenaKomentarStrucnjak");
                });

            modelBuilder.Entity("Models.Korisnik", b =>
                {
                    b.HasOne("Models.Sajt", "KorisnikSajt")
                        .WithMany("Korisnici")
                        .HasForeignKey("KorisnikSajtID");

                    b.Navigation("KorisnikSajt");
                });

            modelBuilder.Entity("Models.Obrok", b =>
                {
                    b.HasOne("Models.Plan", "ObrokPlan")
                        .WithMany("PlanObroci")
                        .HasForeignKey("ObrokPlanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ObrokPlan");
                });

            modelBuilder.Entity("Models.Plan", b =>
                {
                    b.HasOne("Models.StrucnoLice", "PlanStrucnjak")
                        .WithMany("StrucnaLicaPlanovi")
                        .HasForeignKey("PlanStrucnjakID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Sajt", null)
                        .WithMany("Planovi")
                        .HasForeignKey("SajtID");

                    b.Navigation("PlanStrucnjak");
                });

            modelBuilder.Entity("Models.Poruka", b =>
                {
                    b.HasOne("Models.Korisnik", "PorukaKorisnik")
                        .WithMany("KorisniciPoruke")
                        .HasForeignKey("PorukaKorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.StrucnoLice", "PorukaStrucnjak")
                        .WithMany("StrucnaLicaPoruke")
                        .HasForeignKey("PorukaStrucnjakID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PorukaKorisnik");

                    b.Navigation("PorukaStrucnjak");
                });

            modelBuilder.Entity("Models.StrucnoLice", b =>
                {
                    b.HasOne("Models.Sajt", "StrucnjakSajt")
                        .WithMany("StrucnaLica")
                        .HasForeignKey("StrucnjakSajtID");

                    b.Navigation("StrucnjakSajt");
                });

            modelBuilder.Entity("Models.Vezba", b =>
                {
                    b.HasOne("Models.Plan", "VezbaPlan")
                        .WithMany("PlanVezbe")
                        .HasForeignKey("VezbaPlanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VezbaPlan");
                });

            modelBuilder.Entity("Models.Korisnik", b =>
                {
                    b.Navigation("KorisniciKomentariIOcene");

                    b.Navigation("KorisniciPoruke");
                });

            modelBuilder.Entity("Models.Plan", b =>
                {
                    b.Navigation("PlanObroci");

                    b.Navigation("PlanVezbe");
                });

            modelBuilder.Entity("Models.Sajt", b =>
                {
                    b.Navigation("Admini");

                    b.Navigation("Korisnici");

                    b.Navigation("Planovi");

                    b.Navigation("StrucnaLica");
                });

            modelBuilder.Entity("Models.StrucnoLice", b =>
                {
                    b.Navigation("StrucnaLicaKomentariIOcene");

                    b.Navigation("StrucnaLicaPlanovi");

                    b.Navigation("StrucnaLicaPoruke");
                });
#pragma warning restore 612, 618
        }
    }
}
