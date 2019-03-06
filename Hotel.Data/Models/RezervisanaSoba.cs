using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotel.Data.Models
{
    public class RezervisanaSoba
    {
        public int Id { get; set; }
        public bool pusenje { get; set; }


        public Rezervacija Rezervacija { get; set; }
        [ForeignKey(nameof(Rezervacija))]
        public int RezervacijaID { get; set; }

        public Soba Soba { get; set; }
        [ForeignKey(nameof(Soba))]
        public int SobaID { get; set; }
    }
}
