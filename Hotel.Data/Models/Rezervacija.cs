using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotel.Data.Models
{
    public class Rezervacija
    {
        public int Id { get; set; }
        public DateTime datumRezervacije { get; set; }
        public DateTime DatumDolaska { get; set; }
        public DateTime DatumOdlska { get; set; }
        public bool Aktivna { get; set; }


        public Gost Gost { get; set; }
        [ForeignKey(nameof(Gost))]
        public int GostID { get; set; }


        public Zaposlenik Zaposlenik { get; set; }
        [ForeignKey(nameof(Zaposlenik))]
        public int _ZaposlenikId { get; set; }


    }
}
