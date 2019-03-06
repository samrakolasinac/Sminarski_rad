using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotel.Data.Models
{
   public class RezervacijaJela
    {
        public int Id { get; set; }
        public DateTime DatumRezervacije { get; set; }

        public Rezervacija Rezervacija { get; set; }
        [ForeignKey(nameof(Rezervacija))]
        public int RezervacijaID { get; set; }

       
    }
}
