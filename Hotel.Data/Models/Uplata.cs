using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotel.Data.Models
{
   public class Uplata
    {
        public int Id { get; set; }
        public double Iznos { get; set; }
        public DateTime Datum { get; set; }

        public Rezervacija Rezervacija { get; set; }
        [ForeignKey(nameof(Rezervacija))]
        public int RezervacijaID { get; set; }

        public Firma Firma { get; set; }
        [ForeignKey(nameof(Firma))]
        public int? FirmaID { get; set; }

        public Zaposlenik Zaposlenik { get; set; }
        [ForeignKey(nameof(Zaposlenik))]
        public int ZaposlenikID { get; set; }

        public TipUplate TipUplate { get; set; }
        [ForeignKey(nameof(TipUplate))]
        public int TipUplateId { get; set; }
    }
}
