using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotel.Data.Models
{
   public class DodatneUslugeRezervacija
    {
        public int Id { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public float Trajanje { get; set; }

        public Rezervacija Rezervacija { get; set; }
        [ForeignKey(nameof(Rezervacija))]
        public int RezervacijaID { get; set; }

        public DodatneUsluge DodatneUsluge { get; set; }
        [ForeignKey(nameof(DodatneUsluge))]
        public int DodatneUslugeID { get; set; }
    }
}
