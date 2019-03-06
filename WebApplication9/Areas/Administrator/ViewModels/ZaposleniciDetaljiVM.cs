using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Areas.Administrator.ViewModels
{
    public class ZaposleniciDetaljiVM
    {
        public int Zaposlenikid { get; internal set; }
        public string DatumRodjenja { get; internal set; }
        public string DatumZaposlenja { get; internal set; }
        public string TipZaposlenika { get; internal set; }
        public double? BrojTekucegRacuna { get; internal set; }
        public string Grad { get; internal set; }
        public string KorisnickoIme { get; internal set; }
        public string Lozinka { get; internal set; }
        public string ImePrezime { get;  set; }
        public string Email { get; set; }
    }
}
