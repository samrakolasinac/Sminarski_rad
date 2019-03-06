using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotel.Data.Models
{
   public class Plata
    {
        public int id { get; set; }
        public decimal Iznos { get; set; }
        public DateTime datum { get; set; }
        public int mjesec { get; set; }
        public int godina { get; set; }

        public Zaposlenik Zaposlenik { get; set; }
        [ForeignKey(nameof(Zaposlenik))]
        public int ZaposlenikID { get; set; }
    }
}
