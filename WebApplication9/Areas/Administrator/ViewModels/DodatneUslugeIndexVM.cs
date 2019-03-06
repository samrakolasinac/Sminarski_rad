using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Areas.Administrator.ViewModels
{
    public class DodatneUslugeIndexVM
    {
        public List<Row> rows { get; set; }
        public class Row
        {
            public int UslugaID { get; internal set; }
            public string Naziv { get; internal set; }
        
        }
    }
}
