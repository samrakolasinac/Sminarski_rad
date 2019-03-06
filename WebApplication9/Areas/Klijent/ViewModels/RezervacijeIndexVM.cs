using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Areas.Klijent.ViewModels
{
    public class RezervacijeIndexVM
    {
        public List<Row> rows { get; set; }
        public int GostID { get; internal set; }
       

        public class Row
        {
            public int RezervacijaID { get; internal set; }
            public int GostId { get; internal set; }
            public string Gost { get; internal set; }
            public DateTime DatumRezervacije { get; internal set; }
            public int ZaposlenikID { get; internal set; }
            public string Zaposlenik { get; internal set; }
            public bool Aktivna { get; internal set; }
        }
    }
}
