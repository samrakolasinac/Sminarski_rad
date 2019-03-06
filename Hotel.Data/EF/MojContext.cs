using Hotel.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data.EF
{
    public class MojContext:DbContext
    {


        public MojContext(DbContextOptions<MojContext> options)
    : base(options)
        {


        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Rezervacija>()

                .HasOne(s => s.Zaposlenik)

                .WithMany()

                .HasForeignKey(s => s._ZaposlenikId)

                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Rezervacija>()

               .HasOne(so => so.Gost)

               .WithMany()

               .HasForeignKey(so => so.GostID)

               .OnDelete(DeleteBehavior.Restrict);

          

        }

        public DbSet<DodatneUsluge> DodatneUsluge { get; set; }
        public DbSet<DodatneUslugeRezervacija> DodatneUslugeRezervacija { get; set; }
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Firma> Firma { get; set; }
        public DbSet<Gost> Gost { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<Jelo> Jelo { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<Plata> Plata { get; set; }
        public DbSet<Rezervacija> Rezervacija { get; set; }
        public DbSet<RezervacijaJela> RezervacijaJela { get; set; }
        public DbSet<RezervisanaSoba> RezervisanaSoba { get; set; }
        public DbSet<SmjeteniGosti> SmjeteniGosti { get; set; }
        public DbSet<Soba> Soba { get; set; }
        public DbSet<StavkeRezervacijeJela> StavkeRezervacijeJela { get; set; }
        public DbSet<TipSobe> TipSobe { get; set; }
        public DbSet<TipUplate> TipUplate { get; set; }
        public DbSet<TipZaposlenika> TipZaposlenika { get; set; }
        public DbSet<Uplata> Uplata { get; set; }
        public DbSet<Zaposlenik> Zaposlenik { get; set; }
        public DbSet<Dogadjaj> Dogadjaj { get; set; }
        public DbSet<TipDogadjaja> TipDogadjaja { get; set; }
        public DbSet<RezervacijaDogadjaj> RezervacijaDogadjaj { get; set; }

    }
}
