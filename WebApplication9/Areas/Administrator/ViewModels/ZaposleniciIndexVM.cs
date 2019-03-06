using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Areas.Administrator.ViewModels
{
    public class ZaposleniciIndexVM
    {
        public List<Row> rows { get; set; }
        public string pretragaString { get; set; }
        public class Row
        {
            public int ZaposlenikID { get; internal set; }
            public string ImePrezime { get; internal set; }
            public string BrojTelefon { get; internal set; }
            public DateTime DatumRodjena { get; internal set; }
            public DateTime DatumZaposlenja { get; internal set; }
            public string JMBG { get; internal set; }
            public string Ime { get; internal set; }
            public string Prezime { get; internal set; }
            public string TipUposlenika { get; internal set; }
            public int nalogID { get; internal set; }
            public string email { get; internal set; }
        }
    }
}
