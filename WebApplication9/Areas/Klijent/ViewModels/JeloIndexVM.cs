using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Areas.Klijent.ViewModels
{
    public class JeloIndexVM
    {
        public List<Row> rows { get; set; }

        public class Row
        {
            public int jeloID { get; internal set; }
            public string Naziv { get; internal set; }
            public string Opis { get; internal set; }
        }
    }
}
