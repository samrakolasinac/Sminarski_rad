using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Areas.Klijent.ViewModels
{
    public class RezervacijeDetaljiVM
    {
        public int RezervacijaID { get; internal set; }
        public DateTime DatumDolaska { get; internal set; }
        public DateTime DatumOdlaska { get; internal set; }
        public string Gost { get; internal set; }
        public List<Row> usluge { get; set; }
        public List<Row> sobe { get; set; }
        public List<Row> dogadjaji { get; set; }
        public List<Row> jela { get; set; }
        public float Total1 { get; internal set; }
        public float Total2 { get; internal set; }
        public float Total { get; internal set; }
        public float Total3 { get; internal set; }
        public float Total4 { get; internal set; }

        public class Row
        {
            public int UslugaID { get; internal set; }
            public string Usluga { get; internal set; }
            public float Cijena { get; internal set; }
            public DateTime Datum { get; internal set; }
            public int SobaID { get; internal set; }
            public string Naziv { get; internal set; }
            public int Sprat { get; internal set; }
            public float CijenaSobe { get; internal set; }
            public int DogadjajID { get; internal set; }
            public string NazivDogadjaja { get; internal set; }
            public string TipDogadjaja { get; internal set; }
            public float CijenaDogadjaja { get; internal set; }
            public int JeloID { get; internal set; }
            public string NazivJela { get; internal set; }
            public float CijenaJela { get; internal set; }
            public int KolicinaJela { get; internal set; }
            public float UkupnaCijenaJela { get; internal set; }
         
        }
    }
}
